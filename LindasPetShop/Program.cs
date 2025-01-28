using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Data;
using SQLitePCL;

namespace LindasPetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();
            
            var services = CreateServiceCollection();

            IProductLogic productLogic = services.GetService<IProductLogic>();

            UIlogic uilogic = services.GetService<UIlogic>();

            uilogic?.Start();
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
            .AddTransient<UIlogic>()
            .AddTransient<IValidator<Product>, ProductValidator>()
            .AddTransient<IProductLogic, ProductLogic>()
            .AddTransient<IProductRepository, ProductRepository>()  
            .AddDbContext<ProductContext>()
            .BuildServiceProvider();
        }
    }
}

    