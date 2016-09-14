﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.controller.player;
using Assets.Scripts.core.command.async;
using Assets.Scripts.core.command.macro.mapper;
using Zenject;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro
{
    public abstract class SequenceMacro : AsyncCommand, ISequenceMacro
    {
        [Inject]
        DiContainer container;

        private readonly List<ISubCommandMapper> _commandMappers = new List<ISubCommandMapper>();
        private ISubCommandMapper _nextCommandMapper;

        protected SequenceMacro()
        {
            Atomic = true;
        }

        public override void Execute(Object data = null)
        {
            base.Execute();

            Prepare();

            Inter(true);
        }

        public virtual void Prepare()
        {

        }

        public ISubCommandMapper Add(Type commandType)
        {
            if (IsCommandType(commandType))
            {
                var commandMapper = container.Resolve<ISubCommandMapper>();
                commandMapper.CommandType = commandType;
                _commandMappers.Add(commandMapper);

                return commandMapper;
            }
            else
            {
                Debug.LogErrorFormat("Add incompatible command type: {0}", commandType);
                throw new SystemException("Add incompatible command type");
            }
        }

        public void Remove(Type commandType)
        {
            if (IsCommandType(commandType))
            {
                foreach (var commandMapper in _commandMappers)
                {
                    if (commandMapper.CommandType == commandType)
                    {
                        _commandMappers.Remove(commandMapper);
                        return;
                    }
                }
            }
            else
            {
                Debug.LogErrorFormat("Remove incompatible command type: {0}", commandType);
                throw new SystemException("Remove incompatible command type");
            }
        }

        public void Cancel()
        {
            _commandMappers.Clear();
            _nextCommandMapper = null;
            DispatchComplete(false);
        }

        private void Inter(bool successPrevious)
        {
            if (Atomic && !successPrevious)
            {
                Cancel();
                return;
            }

            if (_commandMappers.Count > 0)
            {
                _nextCommandMapper = _commandMappers[0];
                _commandMappers.RemoveAt(0);
                _nextCommandMapper.CompleteCallBack += Inter;
                _nextCommandMapper.CancelParentCallback += Cancel;
                _nextCommandMapper.Execute();
            }
            else
            {
                _commandMappers.Clear();
                _nextCommandMapper = null;
                DispatchComplete(true);
            }
        }

        private bool IsCommandType(Type commandType)
        {
            return typeof(ICommand).IsAssignableFrom(commandType);
        }

        protected bool Atomic { get; set; }
    }
}
