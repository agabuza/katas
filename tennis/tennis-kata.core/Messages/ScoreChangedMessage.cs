using tennis_kata.core.Model;

namespace tennis_kata.core.Messages
{
    public class ScoreChangedMessage
    {
        private readonly bool serverWinsPoint;

        public ScoreChangedMessage(bool serverWinsPoint)
        {
            this.serverWinsPoint = serverWinsPoint;
        }

        public bool ServerWinsPoint
        {
            get
            {
                return serverWinsPoint;
            }
        }
    }
}
