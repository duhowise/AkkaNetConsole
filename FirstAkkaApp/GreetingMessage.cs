namespace FirstAkkaApp
{
    public class GreetingMessage
    {
        public string Greeting { get;  }

        public GreetingMessage(string greeting)
        {
            Greeting = greeting;
        }
    }
}