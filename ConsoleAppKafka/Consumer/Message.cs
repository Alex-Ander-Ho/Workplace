﻿using System.Text.Json;

namespace Workplace.Kafka.Consumer;

public class Message
{
    public string? Id { get; set; }
    public string? Data { get; set; }
    public DateTime Timestamp { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}