namespace MusicApp
{
    internal class StopPlayingMessage
    {
        public string User { get; }

        public StopPlayingMessage(string user)
        {
            User = user;
        }
    }
}