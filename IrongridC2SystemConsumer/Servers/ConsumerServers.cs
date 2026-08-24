using Confluent.Kafka;
using IrongridC2SystemConsumer.Context;
using IrongridC2SystemConsumer.Model;
using IrongridC2SystemConsumer.Validation;
using System;
using System.Text.Json;
namespace IrongridC2SystemConsumer.Servers
{
    public class ConsumerSrvers
    {
        private  AssetLiveDbContext _context;

        public ConsumerSrvers(AssetLiveDbContext context)
        {
            _context = context;
        }

        public async Task StartAsync(string topic)
        {
            var validation = new Consumervalidation();

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = ""
            };

            var consumer = new ConsumerBuilder<Null, string>(config).Build();

            consumer.Subscribe(topic);

            while(true)
            {
                var result = consumer.Consume(TimeSpan.FromSeconds(10));

                if (result == null|| result.Message.Value == null)
                {
                    Console.WriteLine("fINISH");
                    break;
                }

                var message = JsonSerializer.Deserialize<MessageModel>(result.Message.Value);

                var assetLiveStatus = validation.checkStatus(message);

                await _context.AddAsync(assetLiveStatus);
                await _context.SaveChangesAsync();


            }
        }
    }
}