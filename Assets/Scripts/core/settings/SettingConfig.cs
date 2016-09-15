using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.core.settings
{
    struct SettingConfig
    {
        public string Name;
        public Type Type;
        public string EventName;
        public object DefaultValue;
    }
}
