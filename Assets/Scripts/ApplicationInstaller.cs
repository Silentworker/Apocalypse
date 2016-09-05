using System;
using Assets.Scripts.controller;
using Assets.Scripts.controller.camera;
using Assets.Scripts.controller.commands;
using Assets.Scripts.controller.hatch;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.controller.player;
using Assets.Scripts.core.command.macro.mapper;
using Assets.Scripts.core.command.map;
using Assets.Scripts.core.config;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.model.core;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public CameraController cameraController;
        public HeadsUpController headsUpController;
        public PlayerController playerController;
        public HatchController hatchController;

        public override void InstallBindings()
        {
            Container.Bind<IEventDispatcher>().To<EventDispatcher>().AsSingle();
            Container.Bind<ISubCommandMapper>().To<SubCommandMapper>();
            Container.Bind<ICommandsMap>().To<CommandsMap>().AsSingle();
            Container.Bind<IConfig>().To<CommandsConfig>().AsSingle();
            Container.Bind<ApplicationModel>().AsSingle();

            Container.Bind<ICameraController>().FromInstance(cameraController);
            Container.Bind<IHeadsUpController>().FromInstance(headsUpController);
            Container.Bind<IPlayerController>().FromInstance(playerController);
            Container.Bind<IHatchController>().FromInstance(hatchController);
        }
    }
}