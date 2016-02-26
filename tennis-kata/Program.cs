using GalaSoft.MvvmLight.Messaging;
using System;
using tennis_kata.core;
using tennis_kata.core.Messages;

namespace tennis_kata
{
    class Program
    {
        static void Main(string[] args)
        {            
            var messenger = new Messenger();
            var engine = new GameEngine(messenger);

            messenger.Register<GameFinishedMessage>(engine,
                (msg) =>
                {
                    Console.WriteLine($"Game finished! Player {(msg.ServerWinsGame ? 1 : 2)} won!");
                });

            var playerNum = 0;
            while (!engine.IsGameFinished)
            {                
                Console.WriteLine($"Score: {engine.Score.ToString()}");
                Console.WriteLine("Please enter the player that wins the point (1 or 2) :");
                if (int.TryParse(Console.ReadLine(), out playerNum))
                {
                    if (playerNum != 1 && playerNum != 2)
                    {
                        Console.WriteLine("Incorrect input. Please try again.");
                        continue;
                    }

                    messenger.Send(new ScoreChangedMessage(playerNum == 1));
                }
            }

            Console.ReadLine();
        }
    }
}
