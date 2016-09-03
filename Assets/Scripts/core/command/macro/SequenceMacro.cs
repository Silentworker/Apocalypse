using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.core.command.async;
using Assets.Scripts.core.command.macro.mapper;
using Zenject;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro
{
    public abstract class SequenceMacro : AsyncCommand, ISequenceMacro
    {
        [Inject]
        DiContainer container;

        private readonly List<ISubCommandMapper> _commands = new List<ISubCommandMapper>();
        private ISubCommandMapper _currenCommand;

        public override void Execute(Object data = null)
        {
            base.Execute();

            Prepare();

            Bitwixt();
        }

        public virtual void Prepare()
        {

        }

        private void Bitwixt()
        {
            if (_commands.Count > 0)
            {
                _currenCommand = _commands[0];
                _commands.RemoveAt(0);
                _currenCommand.CompleteCallBack = Bitwixt;
                _currenCommand.Execute();
            }
            else
            {
                DispatchComplete(true);
            }
        }

        public ISubCommandMapper Add(Type commandType)
        {
            if (IsCommandType(commandType))
            {
                ISubCommandMapper command = container.Instantiate<SubCommandMapper>();
                command.CommandType = commandType;
                _commands.Add(command);
                return command;
            }
            else
            {
                Debug.LogErrorFormat("Add incompatible command type: {0}", commandType);
                throw new SystemException("Add incompatible command type");
            }
        }

        public void Remove(Type commandType)
        {
            if (IsCommandType(commandType))
            {
                foreach (ISubCommandMapper command in _commands)
                {
                    if (command.CommandType == commandType)
                    {
                        _commands.Remove(command);
                        return;
                    }
                }
            }
            else
            {
                Debug.LogErrorFormat("Remove incompatible command type: {0}", commandType);
                throw new SystemException("Remove incompatible command type");
            }
        }

        public void Cancel()
        {
            _commands.Clear();
            DispatchComplete(false);
        }

        private bool IsCommandType(Type commandType)
        {
            return commandType.IsAssignableFrom(typeof(ICommand));
        }
    }
}
