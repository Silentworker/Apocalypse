using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Assets.Scripts.model.level.wave;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.model.level.parser
{
    public class ConfigParser : IConfigParser
    {
        private XmlNode _root;
        private List<LevelConfigModel> _levels = new List<LevelConfigModel>();
        public ConfigParser()
        {
            var textAsset = (TextAsset)Resources.Load("XML/LevelConfig");
            if (textAsset == null) throw new Exception("Level config file not found");
            var xml = new XmlDocument();
            xml.LoadXml(textAsset.text);

            _root = xml.DocumentElement;

            var levelList = _root.SelectNodes("Level");

            if (levelList != null)
            {
                foreach (XmlNode levelNode in levelList)
                {
                    _levels.Add(ParseLevelXMLNode(levelNode));
                }
            }
            else
            {
                Debug.LogError("No levels inlevel config file");
            }
        }

        public LevelConfigModel GetLevel(int id)
        {
            return _levels.FirstOrDefault(level => level.Id == id);
        }

        private LevelConfigModel ParseLevelXMLNode(XmlNode levelNode)
        {
            var level = new LevelConfigModel { Waves = new List<WaveModel>() };

            if (levelNode.Attributes != null && levelNode.Attributes["Id"] != null)
            {
                if (!int.TryParse(levelNode.Attributes["Id"].Value, out level.Id))
                {
                    Debug.LogError("Level ID must be of type int");
                }
            }
            else
            {
                Debug.LogError("Level config is missing ID attribute");
            }

            var waveList = levelNode.SelectNodes("Wave");

            if (waveList != null)
            {
                foreach (XmlNode waveNode in waveList)
                {
                    level.Waves.Add(ParseWaveXMLNode(waveNode));
                }
            }
            else
            {
                Debug.LogError("No waves in LevelConfig.xml");
            }

            return level;
        }

        private WaveModel ParseWaveXMLNode(XmlNode waveNode)
        {
            var wave = new WaveModel();
            var award = new AwardModel();
            wave.Award = award;

            if (waveNode.Attributes != null && waveNode.Attributes["Id"] != null)
            {
                if (!int.TryParse(waveNode.Attributes["Id"].Value, out wave.Id))
                {
                    Debug.LogError("Wave ID must be of type int");
                }
            }
            else
            {
                Debug.LogError("Wave config is missing ID attribute");
            }

            var awardList = waveNode.SelectNodes("Award");

            if (awardList != null && awardList[0].Attributes != null)
            {
                int.TryParse(awardList[0].Attributes["Score"].Value, out award.Score);
            }

            var zombieList = waveNode.SelectNodes("Zombie");

            if (zombieList == null) return wave;

            wave.Zombies = new List<ZombieModel>();

            foreach (XmlNode zombieNode in zombieList)
            {
                wave.Zombies.AddRange(ParseZombieXMLNode(zombieNode));
            }

            return wave;
        }

        private IEnumerable<ZombieModel> ParseZombieXMLNode(XmlNode node)
        {

            if (node.Attributes == null) throw new Exception("No attributes in Zombie config");
            var attributes = node.Attributes;

            int zombiesAmount = attributes["Amount"] != null ? (int)getAttributeValue(getAttributeRange(attributes["Amount"].Value)) : 1;
            Debug.LogFormat("Zombies Amount:{0}", zombiesAmount);

            List<ZombieModel> result = new List<ZombieModel>();
            try
            {
                for (var i = 0; i < zombiesAmount; i++)
                {
                    var zombie = new ZombieModel();

                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        PropertyInfo propertyInfo = typeof(ZombieModel).GetProperty(attribute.Name);
                        if (propertyInfo != null)
                        {
                            Type valueType = propertyInfo.PropertyType;
                            float[] range = getAttributeRange(attribute.Value);
                            float unConvertedValue = getAttributeValue(range);
                            var value = valueType == typeof(int) ? (int)Math.Round(unConvertedValue) : Convert.ChangeType(unConvertedValue, valueType);
                            propertyInfo.SetValue(zombie, value, null);
                        }
                    }
                    result.Add(zombie);
                }
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Zombie config parse error: {0}", e.Message);
            }

            return result;
        }


        private float getAttributeValue(float[] range)
        {
            return range.Length == 1 ? range[0] : Random.Range(range[0], range[1] + 1);
        }


        private float[] getAttributeRange(string value)
        {
            float[] result;
            if (value.Contains(':'))
            {
                result = new float[2];
                var splitValue = value.Split(':');

                if (!(float.TryParse(splitValue[0], out result[0]) && float.TryParse(splitValue[1], out result[1])))
                {
                    Debug.LogError("Wrong zombie attribute format");
                }
            }
            else
            {
                result = new float[1];
                if (!(float.TryParse(value, out result[0])))
                {
                    Debug.LogError("Wrong zombie attribute format");
                }
            }
            return result;
        }
    }
}
