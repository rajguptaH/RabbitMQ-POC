// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Cunsumer!");


var factory = new ConnectionFactory()
{
    HostName = "localhost"
};
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
var cunsumer = new EventingBasicConsumer(channel);
cunsumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var result = Encoding.UTF8.GetString(body);
    Console.WriteLine("Incoming Message: " + result);
};
channel.BasicConsume("main_queue",true,cunsumer);
Console.ReadLine();
