// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<ICar, Car>();
//serviceCollection.AddScoped<ICar, Car>();   
//serviceCollection.AddTransient<ICar, Car>();


ServiceProvider provider = serviceCollection.BuildServiceProvider(); //IOC Container ist hiermit fertig initiiert 



ICar car = provider.GetRequiredService<ICar>(); //Bei Drittanbieter wie AutoFac oder Ninject, wird die Provider-Klasse ausgetauscht. 

Console.WriteLine(car.Brand);
Console.WriteLine(car.Model);
Console.WriteLine(car.ConstructionYear);


public interface ICar
{
    string Brand { get; set; }
    string Model { get; set; }
    int ConstructionYear { get; set; }
}

public class Car : ICar
{
    public string Brand { get; set; } = "VM";
    public string Model { get; set; } = "Polo";
    public int ConstructionYear { get; set; } = 2018;
}