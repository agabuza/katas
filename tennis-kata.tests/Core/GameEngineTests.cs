using NUnit.Framework;
using tennis_kata.core;
using GalaSoft.MvvmLight.Messaging;
using tennis_kata.core.Messages;
using tennis_kata.core.Model;
using System;

namespace tennis_kata.tests.Core
{
    [TestFixture]
    public class GameEngineTests
    {
        private GameEngine gameEngine;
        private IMessenger messenger;

        [SetUp]
        public void Setup()
        {
            this.messenger = new Messenger();
            this.gameEngine = new GameEngine(messenger);
        }

        [Test]
        public void Whether_GameEngine_InitializesScore_On_Init()
        {
            Assert.That(this.gameEngine.Score.Equals(new Score(Points._0, Points._0)));
        }

        [Test]
        public void Whether_GameEngine_IncrementsScore_On_ScoreChangedMessage()
        {
            this.messenger.Send(new ScoreChangedMessage(true));

            Assert.That(this.gameEngine.Score.Equals(new Score(Points._15, Points._0)));
        }

        [TestCase(Points._40, Points._30, true)]
        [TestCase(Points._40, Points._A, false)]
        public void Whether_GameEngine_DeclaresWinner_On_ScoreChangedMessage(Points serverPoints, Points receiverPoints, bool serverWinsPoint)
        {
            var gameFinished = false;
            var serverWins = false;
            this.gameEngine.Score = new Score(serverPoints, receiverPoints);
            this.messenger.Register<GameFinishedMessage>(this, (msg) => {
                gameFinished = true;
                serverWins = msg.ServerWinsGame;
            });

            this.messenger.Send(new ScoreChangedMessage(serverWinsPoint));

            Assert.That(gameFinished);
            Assert.That(serverWins == serverWinsPoint);
        }

        [Test]
        public void Whether_GameEngine_DeducesScore_On_ScoreChangedMessage()
        {
            this.gameEngine.Score = new Score(Points._A, Points._40);

            this.messenger.Send(new ScoreChangedMessage(false));

            Assert.That(this.gameEngine.Score.Equals(new Score(Points._40, Points._40)));
        }
    }
}
