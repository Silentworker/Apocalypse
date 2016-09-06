﻿using System;
using System.Collections.Generic;
using Assets.Scripts.core.command.async;
using Assets.Scripts.core.command.events;
using Assets.Scripts.core.delegates;
using Assets.Scripts.core.eventdispatcher;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro.mapper
{
    public class SubCommandMapper : ISubCommandMapper
    {
        [Inject]
        DiContainer container;

        private readonly List<ICommand> _asyncCommandsCahe = new List<ICommand>();

        private Type[] _guardTypes;
        private Object _data;

        public Type CommandType { get; set; }

        public Custom.VoidDelegate CompleteCallBack { get; set; }

        private void CompleteCommandHandler(ICommand command)
        {
            if (_asyncCommandsCahe.Contains(command)) _asyncCommandsCahe.Remove(command);

            if (CompleteCallBack != null) CompleteCallBack();
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

                var command = container.Instantiate(CommandType) as ICommand;

                if (command is AsyncCommand)
                {
                    _asyncCommandsCahe.Add(command);
                    (command as AsyncCommand).CompleteHandler += CompleteCommandHandler;
                    command.Execute(_data);
                    return;
                }

                command.Execute(_data);
            }

            if (CompleteCallBack != null) CompleteCallBack();
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
