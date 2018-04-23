using System;
using Akka.Actor;

namespace MusicApp
{
    internal class MusicPlayerActor:ReceiveActor
    {
        protected PlaySongMessage CurrentSong;
        public MusicPlayerActor()
        {
            StoppedBehavior();
        }
        private void StoppedBehavior()
        {
            Receive<PlaySongMessage>(m => PlaySong(m));
            Receive<StopPlayingMessage>(m => Console.WriteLine($"{m.User}'splayer: Cannot stop, the actor is already stopped"));
        }

        private void PlaySong(PlaySongMessage message)
        {
            CurrentSong = message;
            Console.WriteLine($"{CurrentSong.User} is currently listening to'{CurrentSong.Song}'");
            DisplayInformation();
            Become(PlayingBehavior);
        }

        private void DisplayInformation()
        {
            Console.WriteLine("Actors Information:");
            Console.WriteLine($"Typed Actor Named: {Self.Path.Name}");
            Console.WriteLine($"Actor's Path: {Self.Path}");
            Console.WriteLine($"Actor is part of the system: {Context.System.Name}");
            Console.WriteLine($"Actor's Parent is: {Context.Self.Path.Parent.Name}");
        }

        private void PlayingBehavior()
        {
            Receive<PlaySongMessage>(m =>
                Console.WriteLine($"{CurrentSong.User}'s player: Cannot play. Currently playing '{CurrentSong.Song}'"));
            Receive<StopPlayingMessage>(m => StopPlaying());
        }

        private void StopPlaying()
        {
            Console.WriteLine($"{CurrentSong.User}'s player is currently stopped.");
            CurrentSong = null;
            Become(StoppedBehavior);
        }
    }
}