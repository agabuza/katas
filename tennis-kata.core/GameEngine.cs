using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using tennis_kata.core.IO;
using tennis_kata.core.Model;

namespace tennis_kata.core
{
    public class GameEngine
    {
        private IMessenger messenger;

        public GameEngine(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public Score Score { get; internal set; }
    }
}
