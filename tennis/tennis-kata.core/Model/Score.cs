namespace tennis_kata.core.Model
{
    public struct Score
    {
        private Points receiver;
        private Points server;

        public Score(Points server, Points receiver)
        {
            this.server = server;
            this.receiver = receiver;
        }

        public Points Receiver
        {
            get
            {
                return receiver;
            }
        }

        public Points Server
        {
            get
            {
                return server;
            }
        }

        public override string ToString()
        {
            return $"{Server.GetPointString()}:{Receiver.GetPointString()}";
        }
    }
}
