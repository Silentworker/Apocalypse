using Assets.Scripts.controller;
using Assets.Scripts.controller.commands;
using Assets.Scripts.core;
using Assets.Scripts.core.command;
using UnityEngine;

namespace Assets.Scripts
{
    public class ApplicationInit : MonoBehaviour
    {

        private CommandsConfig _commandConfig;

        void Start()
        {
            _commandConfig = new CommandsConfig();
            _commandConfig.Init();

        }
    }
}
