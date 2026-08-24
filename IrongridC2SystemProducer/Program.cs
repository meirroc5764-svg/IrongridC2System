using Confluent.Kafka;
using System;
using System.Text.Json;


var config = new ProducerConfig
{
    BootstrapServers = "localhost"
};

var produser = new ProducerBuilder<Null, string>(config).Build();

var data = File.ReadAllText("Data/field_reports.json");

JsonDocument document = JsonDocument.Parse(data);

var fixDocument = document.RootElement.EnumerateArray();

foreach (var item in fixDocument)
{
    var message = new Message<Null, string>
    {
        Value = item.GetRawText()
    };


    if (message.Value.Contains("PerimeterSensor"))
    {
        await produser.ProduceAsync("PerimeterSensor", message);
    }

    if (message.Value.Contains("UAV"))
    {
        await produser.ProduceAsync("UAV", message);
    }
}