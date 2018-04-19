using Akka.Actor;

namespace AkkaCalculate
{
    public class CalculatorActor:ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<Add>(add => Sender.Tell(new Answer(add.Term1 + add.Term2)));
        }
    }
}