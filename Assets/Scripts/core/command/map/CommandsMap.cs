using System;
using System.Collections.Generic;
using Assets.Scripts.core.command.macro.mapper;
using Assets.Scripts.core.eventdispatcher;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.map
{
    public class CommandsMap : ICommandsMap
    {
        [Inject]
        private IEventDispatcher eventDispatcher;
        [Inject]
        private DiContainer container;

        private readonly List<ISubCommandMapper> _eventCommandMappers = new List<ISubCommandMapper>();
        private readonly List<ISubCommandMapper> _directCommandMappers = new List<ISubCommandMapper>();

        public ISubCommandMapper Map(string eventType, Type commandType)
        {
            var commandMapper = container.Resolve<ISubCommandMapper>();
            commandMapper.CommandType = commandType;
            eventDispatcher.AddEventListener(eventType, commandMapper.Execute);
            _eventCommandMappers.Add(commandMapper);

            Debug.LogFormat("Command {0} maped to {1}", commandType, eventType);
            return commandMapper;
        }

        public void UnMap(string eventType, Type commandType)
        {
            foreach (var commandMapper in _eventCommandMappers)
            {
                if (commandMapper.CommandType == commandType)
                {
                    eventDispatcher.RemoveEventListener(eventType, commandMapper.Execute);
                    _eventCommandMappers.Remove(commandMapper);
                }
            }
        }

        public void DirectCommand(Type commandType, Object data = null)
        {
            if (IsCommandType(commandType))
            {
                ISubCommandMapper directMapper = null;

                foreach (var mapper in _directCommandMappers)
                {
                    if (mapper.CommandType == commandType)
                    {
                        directMapper = mapper;
                        break;
                    }
                }

                if (directMapper == null)
                {
                    directMapper = container.Resolve<ISubCommandMapper>();
                    directMapper.CommandType = commandType;
                    _directCommandMappers.Add(directMapper);
                }

                directMapper.Execute(data);
            }
            else
            {
                Debug.LogErrorFormat("Incompatible direct command type: {0}", commandType);
                throw new SystemException("Incompatible direct command type");
            }
        }

        private bool IsCommandType(Type commandType)
        {
            return typeof(ICommand).IsAssignableFrom(commandType);
        }
    }
}