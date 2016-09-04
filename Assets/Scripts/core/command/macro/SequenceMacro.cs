using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.controller.player;
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

        private readonly List<ISubCommandMapper> _commandMappers = new List<ISubCommandMapper>();
        private ISubCommandMapper _nextCommandMapper;

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
            if (_commandMappers.Count > 0)
            {
                _nextCommandMapper = _commandMappers[0];
                _commandMappers.RemoveAt(0);
                _nextCommandMapper.CompleteCallBack += Bitwixt;
                _nextCommandMapper.Execute();
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
                ISubCommandMapper commandMapper = container.Instantiate<SubCommandMapper>();
                commandMapper.CommandType = commandType;
                _commandMappers.Add(commandMapper);


                return commandMapper;
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
                foreach (ISubCommandMapper commandMapper in _commandMappers)
                {
                    if (commandMapper.CommandType == commandType)
                    {
                        _commandMappers.Remove(commandMapper);
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
            _commandMappers.Clear();
            DispatchComplete(false);
        }

        private bool IsCommandType(Type commandType)
        {
            return typeof(ICommand).IsAssignableFrom(commandType); 
        }
    }
}
