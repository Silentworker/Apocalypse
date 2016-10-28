using Assets.Scripts.controller.camera;
using Assets.Scripts.controller.commands;
using Assets.Scripts.controller.hatch;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.controller.player;
using Assets.Scripts.controller.settings;
using Assets.Scripts.controller.zombie;
using Assets.Scripts.model.core;
using Assets.Scripts.model.level.executor;
using Assets.Scripts.model.level.parser;
using Assets.Scripts.sw.core.command.macro.mapper;
using Assets.Scripts.sw.core.command.map;
using Assets.Scripts.sw.core.config;
using Assets.Scripts.sw.core.eventdispatcher;
using Assets.Scripts.sw.core.settings;
using Zenject;

namespace Assets.Scripts
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public CameraController cameraController;
        public HeadsUpController headsUpController;
        public PlayerController playerController;
        public HatchController hatchController;
        public ZombieFactory zombieFactory;

        public override void InstallBindings()
        {
            Container.Bind<IEventDispatcher>().To<EventDispatcher>().AsSingle().NonLazy();
            Container.Bind<ISubCommandMapper>().To<SubCommandMapper>();
            Container.Bind<ICommandsMap>().To<CommandsMap>().AsSingle();
            Container.Bind<IConfig>().To<CommandsConfig>().AsSingle();
            Container.Bind<ILevelExecutor>().To<LevelExecutor>().AsSingle();
            Container.Bind<ISettingsManager>().To<SettingsManager>().AsSingle().NonLazy();
            Container.Bind<IConfigParser>().To<ConfigParser>().AsSingle();

            Container.Bind<ApplicationModel>().AsSingle().NonLazy();

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~
                MonoBehaviour controllers
               ~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
            Container.Bind<ICameraController>().FromInstance(cameraController);
            Container.Bind<IHeadsUpController>().FromInstance(headsUpController);
            Container.Bind<IPlayerController>().FromInstance(playerController);
            Container.Bind<IHatchController>().FromInstance(hatchController);
            Container.Bind<IZombieFactory>().FromInstance(zombieFactory);
        }
    }
}