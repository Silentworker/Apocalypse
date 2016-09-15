using Assets.Scripts.core.command;
using UnityEngine;

namespace Assets.Scripts.controller.commands.pause
{
    public class PauseGameCommand : Command
    {

        public override void Execute(Object data = null)
        {
            base.Execute();

            Time.timeScale = 0;
        }
    }
}
