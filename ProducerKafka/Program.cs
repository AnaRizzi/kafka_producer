using Confluent.Kafka;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProducerKafka
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = Dns.GetHostName(),
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var x = await producer.ProduceAsync("KAFKA_TESTE", new Message<string, string> { Key = "campo1", Value = "mensagem do kafka", Timestamp = new Timestamp(DateTime.Now) });

                Console.WriteLine(x.Offset);
            }

            Console.ReadKey();
        }

    }
}
