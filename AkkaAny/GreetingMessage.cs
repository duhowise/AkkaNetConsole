namespace AkkaAny
{
    public class GreetingMessage
    {
        public GreetingMessage(string greeting)
        {
            Greeting = greeting;
        }
        public string Greeting { get; private set; }
    }
}