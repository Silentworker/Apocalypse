using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.map
{
    public class CommandMap : ICommandMap
    {
        private readonly Dictionary<string, Type> _commandsTypeDictionary = new Dictionary<string, Type>();

        private static CommandMap _instance;

        private static CommandMap Instance
        {
            get { return _instance ?? (_instance = new CommandMap()); }
        }

        public void map(string eventType, Type commandType)
        {
            _commandsTypeDictionary[eventType] = commandType;

            UnityAction<Object> action = GetCommandAction(commandType);

            if (action != null)
            {
                EventDispatcher.AddEventListener(eventType, action);
                Debug.LogFormat("Command {0} maped to {1}", commandType, eventType);
            }
            else
            {
                Debug.LogError("Command map error");
            }
        }

        public static void Map(string eventType, Type commandType)
        {
            Instance.map(eventType, commandType);
        }

        public void unMap(string eventType, Type commandType)
        {
            Type checkType = null;
            if (Instance._commandsTypeDictionary.TryGetValue(eventType, out checkType))
            {
                if (checkType == commandType)
                {
                    Instance._commandsTypeDictionary.Remove(eventType);
                }
            }
        }

        public static void UnMap(string eventType, Type commandType)
        {
            Instance.unMap(eventType, commandType);
        }


        private UnityAction<Object> GetCommandAction(Type commandType)
        {
            ICommand command = Activator.CreateInstance(commandType) as ICommand;
            return new UnityAction<Object>((data) => { command.Execute(data); });
        }
    }
}