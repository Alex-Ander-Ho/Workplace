using Confluent.Kafka;
using Workplace.Client.Data;
using Workplace.Shared;

namespace Workplace.Kafka.Consumer;
public class Consumer<T>
{
    readonly string? _host;
    readonly int _port;
    readonly string? _topic;

    public Consumer()
    {
        _host = "localhost";
        _port = 9092;
        _topic = "topic-test";
    }

    ConsumerConfig GetConsumerConfig()
    {
        return new ConsumerConfig
        {
            BootstrapServers = $"{_host}:{_port}",
            GroupId = "foo",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
    }

    public async Task ConsumeAsync()
    {
        using (var consumer = new ConsumerBuilder<Ignore, string>(GetConsumerConfig()).Build())
        {
            consumer.Subscribe(_topic);

            Console.WriteLine($"Subscribed to {_topic}");

            await Task.Run(async () =>
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(default(CancellationToken));
                    MockData data = new MockData();
                    await data.UpdateAsync(new TaskItemDTO()
                    {
                        Id = 0,
                        Name = "Задача 0",
                        Description = consumeResult.Message.Value,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(1),
                        Location = "Место 0",
                        Teacher = "Преподаватель 0"
                    });
                }
            });

            consumer.Close();
        }
    }
}