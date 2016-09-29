using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.model;
using Assets.Scripts.model.level.wave;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.level
{
    public class LevelModel : Model, ILevel
    {
        private List<WaveModel> _waves = new List<WaveModel>();

        public LevelModel(IEventDispatcher dispatcher, DiContainer container) : base(dispatcher, container)
        {
            var textAsset = (TextAsset)Resources.Load("XML/LevelConfig");
            var xml = new XmlDocument();
            xml.LoadXml(textAsset.text);
            XmlNode root = xml.DocumentElement;

            Debug.LogFormat("Root name: {0}", root.LocalName);

            XmlNodeList waveList = root.SelectNodes("wave");

            if (waveList != null)
            {
                foreach (XmlNode waveNode in waveList)
                {
                    _waves.Add(GetWaveModelFromXmlNode(waveNode));
                }
            }
            else
            {
                Debug.LogError("No waves in LevelConfig.xml");
            }
        }

        private WaveModel GetWaveModelFromXmlNode(XmlNode node)
        {
            var wave = new WaveModel();
            var award = new AwardModel();
            wave.Award = award;

            XmlNodeList awardList = node.SelectNodes("award");

            if (awardList != null && awardList[0].Attributes != null)
            {
                int.TryParse(awardList[0].Attributes["score"].Value, out award.Score);
            }

            XmlNodeList zombieList = node.SelectNodes("zombie");

            if (zombieList != null)
            {
                wave.Zombies = new List<ZombieModel>();

                foreach (XmlNode zombieNode in zombieList)
                {
                    wave.Zombies.Add(GetZombieModelFromNode(zombieNode));
                }
            }

            return wave;
        }

        private ZombieModel GetZombieModelFromNode(XmlNode zombieNode)
        {
            var zombie = new ZombieModel();

            if (zombieNode.Attributes == null) return zombie;

            if (zombieNode.Attributes[ZombieModel.TypeAttribute] != null)
                int.TryParse(zombieNode.Attributes[ZombieModel.TypeAttribute].Value, out zombie.Type);

            if (zombieNode.Attributes[ZombieModel.HealthAttribute] != null)
                float.TryParse(zombieNode.Attributes[ZombieModel.HealthAttribute].Value, out zombie.Health);

            if (zombieNode.Attributes[ZombieModel.SpeedAttribute] != null)
                float.TryParse(zombieNode.Attributes[ZombieModel.SpeedAttribute].Value, out zombie.Speed);

            if (zombieNode.Attributes[ZombieModel.HitDamageAttribute] != null)
                int.TryParse(zombieNode.Attributes[ZombieModel.HitDamageAttribute].Value, out zombie.HitDamage);

            if (zombieNode.Attributes[ZombieModel.HitDelayAttribute] != null)
                float.TryParse(zombieNode.Attributes[ZombieModel.HitDelayAttribute].Value, out zombie.HitDelay);

            if (zombieNode.Attributes[ZombieModel.SpawndDelayAttribute] != null)
                float.TryParse(zombieNode.Attributes[ZombieModel.SpawndDelayAttribute].Value, out zombie.SpawnDelay);

            if (zombieNode.Attributes[ZombieModel.SpawndPositionAttribute] != null)
                float.TryParse(zombieNode.Attributes[ZombieModel.SpawndPositionAttribute].Value, out zombie.SpawnPosition);

            return zombie;
        }

        public void Start()
        {

        }

        public void Reset()
        {

        }
    }
}
