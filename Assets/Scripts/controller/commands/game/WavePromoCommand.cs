﻿using System.Timers;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.async;
using ModestTree;
using Zenject;

namespace Assets.Scripts.controller.commands.game
{
    public class WavePromoCommand : AsyncCommand
    {
        [Inject]
        private IHeadsUpController headsUpController;

        private WaveModel _wave;
        private Timer _timer;
        public override void Execute(object data = null)
        {
            base.Execute();

            _wave = (WaveModel)data;

            headsUpController.ShowPrompt("Волна {0} начинается...".Fmt(_wave.Id));

            _timer = new Timer { Interval = 3000, AutoReset = false };
            _timer.Elapsed += delegate { delayedComplete(); };
            _timer.Start();
        }

        private void delayedComplete()
        {
            _timer.Dispose();
            DispatchComplete(true);
        }
    }
}