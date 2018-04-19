using System;
using Akka.Actor;

namespace AkkaCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("calc-system");
            var calculator = system.ActorOf<CalculatorActor>("calculator");


            var result = calculator.Ask<Answer>(new Add(1, 2)).Result;
            Console.WriteLine($"Addition Result: {result.Value}");

            system.Terminate();
        }
    }
}
