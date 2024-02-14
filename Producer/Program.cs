using RabbitMQ.Client;
using System.Text;
public static class Program
{
    public static void Main(string[] args)
    {
        Print();
    }
    public static void Print()
    {
        Console.WriteLine("Want To Send Message Choose Y/Yes!");
        var req = Console.ReadLine();
        if (req.ToLower() == "y" || req.ToLower() == "yes")
        {
            Console.WriteLine("Enter Message!");
            var message = Console.ReadLine();
            Send(message);
        }
        else
        {
            Print();
        }
    }
    public static void Send(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.BasicPublish("main", "main_key", null, Encoding.UTF8.GetBytes(message));
        Console.WriteLine("Message Sent Sucessfully!");
        Print();
    }
}