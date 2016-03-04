namespace tennis_kata.core.Messages
{
    public class GameFinishedMessage
    {
        private readonly bool serverWinsGame;

        public GameFinishedMessage(bool serverWinsGame)
        {
            this.serverWinsGame = serverWinsGame;
        }

        public bool ServerWinsGame
        {
            get
            {
                return serverWinsGame;
            }
        }
    }
}
