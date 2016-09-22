using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.settings;
using Assets.Scripts.model;

namespace Assets.Scripts.service
{
    public class SettingsManager : AbstractSettingManager
    {
        public SettingsManager(IEventDispatcher ed) : base(ed)
        {
        }

        public override void Init()
        {

        }
    }
}
