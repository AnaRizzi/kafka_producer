using System;
using System.Collections.Generic;
using System.Text;

namespace ProducerKafka
{
    public class KafkaMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public KafkaMessage()
        {
            Id = Guid.NewGuid();
            Name = "Teste";
        }
    }
}
