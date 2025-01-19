using System;
using Microsoft.Extensions.DependencyInjection;

namespace LindasPetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            IProductLogic productLogic = services.GetService<IProductLogic>();

            UIlogic uilogic = services.GetService<UIlogic>();

            uilogic?.Start();
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
            .AddTransient<UIlogic>()
            .AddTransient<IProductLogic, ProductLogic>()
            .BuildServiceProvider();
        }
    }
}

    