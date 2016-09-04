using System;
using System.Collections.Generic;
using Assets.Scripts.core.command.async;
using Assets.Scripts.core.delegates;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro.mapper
{
    public class SubCommandMapper : ISubCommandMapper
    {
        [Inject]
        DiContainer container;

        private List<ICommand> _commands = new List<ICommand>();

        private ICommand _command;
        private Type[] _guardTypes;
        private Object _data;

        public Type CommandType { get; set; }

        public Custom.VoidDelegate CompleteCallBack { get; set; }

        public SubCommandMapper()
        {
            CompleteCallBack += Clear;
        }

        private void Clear()
        {
            _command = null;
        }

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

        public void Execute(Object data = null)
        {
            if (GuardsPass())
            {
                if (data != null) _data = data;

                _command = container.Instantiate(CommandType) as ICommand;

                _commands.Add(_command);

                if (_command is AsyncCommand)
                {
                    (_command as AsyncCommand).CompleteHandler += CompleteCallBack;
                    _command.Execute(_data);
                    return;
                }

                _command.Execute(_data);
            }

            CompleteCallBack();
        }

        private bool GuardsPass()
        {
            if (_guardTypes != null)
            {
                foreach (Type guardType in _guardTypes)
                {
                    if (typeof(IGuard).IsAssignableFrom(guardType))
                    {
                        IGuard guard = container.Instantiate(guardType) as IGuard;
                        if (!guard.Let()) return false;
                    }
                    else
                    {
                        throw new SystemException("Incompatible guard type");
                    }
                }
            }
            return true;
        }
    }
}
