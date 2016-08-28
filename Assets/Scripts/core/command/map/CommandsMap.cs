using System;
using System.Collections.Generic;
using Assets.Scripts.controller.commands;
using Assets.Scripts.core.eventdispatcher;
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

        private readonly Dictionary<string, Type> _commandsTypeDictionary = new Dictionary<string, Type>();

        public void Map(string eventType, Type commandType)
        {
            _commandsTypeDictionary[eventType] = commandType;

            UnityAction<Object> action = GetCommandAction(commandType);

            if (action != null)
            {
                eventDispatcher.AddEventListener(eventType, action);
                Debug.LogFormat("Command {0} maped to {1}", commandType, eventType);
            }
            else
            {
                Debug.LogError("Command map error");
            }
        }

        public void UnMap(string eventType, Type commandType)
        {
            // todo: Add removing from EventDispatcher
            Type checkType = null;
            if (_commandsTypeDictionary.TryGetValue(eventType, out checkType))
            {
                if (checkType == commandType)
                {
                    _commandsTypeDictionary.Remove(eventType);
                }
            }
        }

        private UnityAction<Object> GetCommandAction(Type commandType)
        {
            ICommand command = container.Instantiate(commandType) as ICommand;
            return new UnityAction<Object>((data) => { command.Execute(data); });
        }
    }
}