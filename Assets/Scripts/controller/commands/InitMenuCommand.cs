using Assets.Scripts.core.command;
using Assets.Scripts.models;
using UnityEngine;

namespace Assets.Scripts.controller.commands
{
    public class InitMenuCommand : Command
    {

        public override void Execute(Object data = null)
        {
            base.Execute();

            CameraController.MoveToMenuPosition();
        }
    }
}
