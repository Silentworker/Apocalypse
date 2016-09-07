using Assets.Scripts.core.command;
using UnityEngine;

namespace Assets.Scripts.controller.commands.pause
{
    public class ResumeGameCommand : Command
    {
        public override void Execute(Object data = null)
        {
            Time.timeScale = 1;
            base.Execute();
        }
    }
}
