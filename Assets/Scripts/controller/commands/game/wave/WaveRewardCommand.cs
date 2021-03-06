﻿using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.async;
using Assets.Scripts.view.headsup;
using DG.Tweening;
using ModestTree;
using Zenject;

namespace Assets.Scripts.controller.commands.game.wave
{
    public class WaveRewardCommand : AsyncCommand
    {
        [Inject]
        private IHeadsUpController headsUpController;

        private WaveModel _wave;
        public override void Execute(object data = null)
        {
            base.Execute();

            _wave = (WaveModel)data;
            const float promoDuration = 5f;
            headsUpController.ShowPrompt("Волна {0} окончена. Награда {1} очков".Fmt(_wave.Id, _wave.Award.Score), promoDuration);
            DOVirtual.DelayedCall(promoDuration, dellayedComplete);
        }

        private void dellayedComplete()
        {
            _wave = null;
            DispatchComplete(true);
        }
    }
}
