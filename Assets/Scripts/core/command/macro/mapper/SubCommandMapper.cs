using System;
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

        private ICommand _command;
        private Type[] _guardTypes;
        private Object _data;

        public Type CommandType { get; set; }

        public Custom.VoidDelegate CompleteCallBack { get; set; }

        public ISubCommandMapper WithGuards(Type[] guardTypes)
        {
            _guardTypes = guardTypes;
            return this;
        }

        public ISubCommandMapper WithData(Object data)
        {
            _data = data;
            return this;
        }

        public void Execute()
        {
            if (GuardsPass())
            {
                _command = container.Instantiate(CommandType) as ICommand;

                if (_command is AsyncCommand)
                {
                    (_command as AsyncCommand).CompleteHandler = CompleteCallBack;
                    _command.Execute(_data);
                    return;
                }

                _command.Execute(_data);
            }

            CompleteCallBack();
        }

        private bool GuardsPass()
        {
            foreach (Type guardType in _guardTypes)
            {
                if (guardType.IsAssignableFrom(typeof(IGuard)))
                {
                    IGuard guard = container.Instantiate(guardType) as IGuard;
                    if (!guard.Let()) return false;
                }
                else
                {
                    throw new SystemException("Incompatible guard type");
                }
            }
            return true;
        }
    }
}
