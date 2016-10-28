using System.Collections.Generic;
using Assets.Scripts.model.level.wave;

namespace Assets.Scripts.model.level
{
    public class LevelConfigModel
    {
        public int Id;
        public AwardModel Award;
        public List<WaveModel> Waves;
    }
}
