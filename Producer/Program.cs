using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");


var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();


await channel.ExchangeDeclareAsync(exchange: "logs", type: ExchangeType.Fanout);



const string message = "Hello World!33";
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(exchange: "logs", routingKey: string.Empty, body: body);
Console.WriteLine($" [x] Sent {message}");


Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();