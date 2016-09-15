using System;
using System.Collections.Generic;
using Assets.Scripts.core.command.async;
using Assets.Scripts.core.delegates;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro.mapper
{
    public class SubCommandMapper : ISubCommandMapper
    {
        [Inject]
        DiContainer container;

        private readonly List<ICommand> _asyncCommandsCahe = new List<ICommand>();
        private Queue<Type> _guardTypes;
        private Object _data;

        public ISubCommandMapper WithGuard(Type guardType)
        {
            if (!typeof(IGuard).IsAssignableFrom(guardType))
            {
                throw new SystemException("Incompatible guard type");
            }

            if (_guardTypes == null)
            {
                _guardTypes = new Queue<Type>();
            }
            _guardTypes.Enqueue(guardType);

            return this;
        }

        public ISubCommandMapper WithData(Object data)
        {
            _data = data;
            return this;
        }

        public void Execute(Object data = null)
        {
            if (GuardsPass())
            {
                if (data != null) _data = data;

                var command = container.Instantiate(CommandType) as ICommand;
                (command as ISubCommand).CalcelParentCallback = CancelParentCallback;

                if (command is AsyncCommand)
                {
                    _asyncCommandsCahe.Add(command);
                    (command as AsyncCommand).CompleteHandler += CompleteCommandHandler;
                    command.Execute(_data);
                    return;
                }

                command.Execute(_data);
            }

            if (CompleteCallBack != null) CompleteCallBack(true);
        }

        private void CompleteCommandHandler(ICommand command, bool success)
        {
            if (_asyncCommandsCahe.Contains(command)) _asyncCommandsCahe.Remove(command);

            if (CompleteCallBack != null) CompleteCallBack(success);
        }

        private bool GuardsPass()
        {
            if (_guardTypes != null)
            {
                while (_guardTypes.Count > 0)
                {
                    IGuard guard = container.Instantiate(_guardTypes.Dequeue()) as IGuard;
                    if (!guard.Let()) return false;
                }
            }
            return true;
        }

        public Type CommandType { get; set; }

        public CustomDelegate.BoolParameter CompleteCallBack { get; set; }

        public CustomDelegate.Void CancelParentCallback { get; set; }
    }
}
