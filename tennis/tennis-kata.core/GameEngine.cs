using System;
using GalaSoft.MvvmLight.Messaging;
using tennis_kata.core.Model;
using tennis_kata.core.Messages;

namespace tennis_kata.core
{
    public class GameEngine
    {
        private IMessenger messenger;
        private bool isGameFinished;

        public GameEngine(IMessenger messenger)
        {
            this.messenger = messenger;
            this.messenger.Register<ScoreChangedMessage>(this, this.OnScoreChanged);
            this.messenger.Register<GameFinishedMessage>(this, (msg) => this.isGameFinished = true);
        }

        public Score Score { get; internal set; }

        public bool IsGameFinished
        {
            get
            {
                return isGameFinished;
            }
        }

        private void OnScoreChanged(ScoreChangedMessage msg)
        {
            if (this.IsGameFinished)
            {
                throw new ApplicationException("All bets are off!!");
            }            

            if (msg.ServerWinsPoint)
            {               
                this.Score = new Score(this.Score.Server + 1, this.Score.Receiver);
            }
            else
            {
                this.Score = new Score(this.Score.Server, this.Score.Receiver + 1);
            }

            if (this.IsFinished())
            {
                this.messenger.Send(new GameFinishedMessage(msg.ServerWinsPoint));
            }

            this.DeduceScore();
        }

        private void DeduceScore()
        {
            if (this.Score.Server.Equals(Points._A) && this.Score.Receiver.Equals(Points._A))
            {
                this.Score = new Score(this.Score.Server - 1, this.Score.Receiver - 1);
            }
        }

        private bool IsFinished()
        {
            return Math.Abs(this.Score.Receiver - this.Score.Server) >= 2
                && (this.Score.Receiver >= Points._40 || this.Score.Server >= Points._40);
        }        
    }
}
