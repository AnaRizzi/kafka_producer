using Confluent.Kafka;
using System;
using System.Net;
using System.Text;
using System.Text.Json;
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

            var message = new KafkaMessage();
            var jsonObject = JsonSerializer.Serialize(message);

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var x = await producer.ProduceAsync("KAFKA_TESTE", new Message<string, string> { Key = "chave", Value = jsonObject, Timestamp = new Timestamp(DateTime.Now) });

                Console.WriteLine(x.Offset);
            }

            Console.ReadKey();
        }

    }
}
