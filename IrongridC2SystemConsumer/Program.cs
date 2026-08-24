using IrongridC2SystemConsumer.Context;
using IrongridC2SystemConsumer.Servers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

var conectionString = "server=localhost; Database=testDb; User=root; Password=root";

var serves = new ServiceCollection();

var topic = new[]
{
    "UAV",
    "PerimeterSensor"
};


serves.AddDbContext<AssetLiveDbContext>(options => 
options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

serves.AddScoped<AssetLiveDbContext>();

var servesProvaider = serves.BuildServiceProvider();

using (var scope = servesProvaider.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AssetLiveDbContext>();
    db.Database.EnsureCreated();
}

serves.AddScoped<ConsumerSrvers>();

using (var scope = servesProvaider.CreateScope())
{
    var cs = scope.ServiceProvider.GetRequiredService<ConsumerSrvers>();

foreach (var item in topic)
{
    cs.StartAsync(item);
}

}