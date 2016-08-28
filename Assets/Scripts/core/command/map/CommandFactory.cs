using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;

namespace Assets.Scripts.core.command.map
{
    class CommandFactory : IFactory<Type, ICommand>
    {
        public ICommand Create(Type commandType)
        {
            return Activator.CreateInstance(commandType) as ICommand;
        }
    }
}
