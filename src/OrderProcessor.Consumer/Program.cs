using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderProcessor.Services;
using System;
using System.Collections.Generic;

namespace OrderProcessor.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                OrderProcessingService svc = ActivatorUtilities.CreateInstance<OrderProcessingService>(host.Services);

                PrintDetails(svc.ProcessOrder(ProductTypes.PhysicalProduct));
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nError: {e.Message}\n");
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IOrderProcessingService, OrderProcessingService>();
               });

        private static void PrintDetails((List<string> Tasks, string Name) product)
        {
            Console.WriteLine();
            foreach (var task in product.Tasks)
            {
                Console.WriteLine("* " + task);
            }
            Console.WriteLine();
            Console.Write("Press any key for Menu");
            Console.ReadKey();
        }
    }
}