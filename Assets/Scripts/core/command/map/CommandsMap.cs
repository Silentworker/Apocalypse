using System;
using System.Collections.Generic;
using Assets.Scripts.controller.commands;
using Assets.Scripts.core.command.macro.mapper;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.test;
using UnityEngine;
using UnityEngine.Events;
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

        private List<ISubCommandMapper> _commandMappers = new List<ISubCommandMapper>();

        public void Map(string eventType, Type commandType)
        {
            ISubCommandMapper commandMapper = container.Instantiate<SubCommandMapper>();
            commandMapper.CommandType = commandType;
            eventDispatcher.AddEventListener(eventType, commandMapper.Execute);
            _commandMappers.Add(commandMapper);

            Debug.LogFormat("Command {0} maped to {1}", commandType, eventType);
        }

        public void UnMap(string eventType, Type commandType)
        {
            foreach (ISubCommandMapper commandMapper in _commandMappers)
            {
                if (commandMapper.CommandType == commandType)
                {
                    eventDispatcher.RemoveEventListener(eventType, commandMapper.Execute);
                }
            }
        }

        public void DirectCommand(Type commandType, Object data = null)
        {
            if (IsCommandType(commandType))
            {
                ICommand command = container.Instantiate(commandType) as ICommand;
                command.Execute(data);
            }
            else
            {
                Debug.LogErrorFormat("Incompatible command type: {0}", commandType);
            }
        }

        private bool IsCommandType(Type commandType)
        {
            return typeof(ICommand).IsAssignableFrom(commandType);
        }
    }
}