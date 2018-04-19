using System;
using System.Reflection;
using System.Runtime.Remoting;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;

namespace AkkaAny
{
    class Program
    {
        static void Main(string[] args)
        {
            //DownloadActorExecute();
            var builder=new Autofac.ContainerBuilder();
            //builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly()).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly());

            builder.RegisterType<MusicSongService>().As<IMusicSongService>();
            builder.RegisterType<MusicActor>().AsSelf();
            var container = builder.Build();


            var system = ActorSystem.Create("Mysystem");
            var propsResolver = new AutoFacDependencyResolver(container, system);

            IActorRef musicAct = system.ActorOf(system.DI().Props<MusicActor>(),"MusicActor");
            musicAct.Tell("Bohemian Rhapsody");
            Console.Read();
            system.Terminate();
        }

        private static void DownloadActorExecute()
        {
            ActorSystem system = ActorSystem.Create("html-download-system");
            IActorRef receiveAsyncActor = system.ActorOf<DownloadAnyHtmlActor>();
            receiveAsyncActor.Tell("https://www.agile-code.com");
            receiveAsyncActor.Tell(new Uri("https://www.syncfusion.com"));
            receiveAsyncActor.Tell(new GreetingMessage("hi"));
            Console.Read();
            system.Terminate();
        }
    }
}
