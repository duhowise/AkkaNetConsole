using System.Collections.Generic;
using Akka.Actor;

namespace MusicApp
{
    public class MusicPlayerCoordinatorActor:ReceiveActor
    {
        protected Dictionary<string, IActorRef> MusicPlayerActors;

        public MusicPlayerCoordinatorActor()
        {
            MusicPlayerActors =new Dictionary<string, IActorRef>();
            Receive<PlaySongMessage>(message=>PlaySong(message));
            Receive<StopPlayingMessage>(message => StopPlaying(message));
        }

        private void StopPlaying(StopPlayingMessage message)
        {
            var musicPlayerActor = GetMusicPlayerActor(message.User);
            musicPlayerActor?.Tell(message);
        }

        private IActorRef GetMusicPlayerActor(string user)
        {
            MusicPlayerActors.TryGetValue(user, out var musicPlayerActorRef);
            return musicPlayerActorRef;
        }

        private void PlaySong(PlaySongMessage message)
        {
            var musicPlayerActor = EnsureMusicPlayerActorExists(message.User);
            musicPlayerActor.Tell(message);
        }

        private IActorRef EnsureMusicPlayerActorExists(string user)
        {
            var musicPlayerActorRef = GetMusicPlayerActor(user);
            MusicPlayerActors.TryGetValue(user, out musicPlayerActorRef);
            if (musicPlayerActorRef==null)
            {
                musicPlayerActorRef = Context.ActorOf<MusicPlayerActor>(user);
                MusicPlayerActors.Add(user,musicPlayerActorRef);
                
            }

            return musicPlayerActorRef;
        }
    }
}