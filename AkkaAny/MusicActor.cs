using System;
using Akka.Actor;

namespace AkkaAny
{
    public class MusicActor:ReceiveActor
    {
        public MusicActor(IMusicSongService songService)
        {
            SongService = songService;
            Receive<string>(s=>HandleSongRetrieval(s));
        }

        private void HandleSongRetrieval(string songName)
        {
            var song = SongService.GetSongByName(songName);
            Console.WriteLine($"song: {song.SongName}");
        }

        private IMusicSongService SongService { get; }
    }
}