using Assets.Scripts.model.core;
using Assets.Scripts.sw.core.config;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ApplicationInit : MonoBehaviour
    {
        [Inject]
        private IConfig commandsConfig;
        [Inject]
        private ApplicationModel applicationModel;
       
        void Awake()
        {
            Application.targetFrameRate = 60;

            commandsConfig.Init();

            applicationModel.Init();
        }
    }
}
