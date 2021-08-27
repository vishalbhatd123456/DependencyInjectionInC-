using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DependencyInjectionTypes
{
    public class ScopedClass
    {

    }
    public class TransientClass
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ScopedClass>(); //avoids new keyword
            collection.AddTransient<TransientClass>();

            var builder = collection.BuildServiceProvider();

            Parallel.For(1, 10, i =>
             {
                //10 different thread.
                Console.WriteLine($"Scoped ID = {builder.GetService<ScopedClass>().GetHashCode().ToString()}");
                 Console.WriteLine($"Transient ID = {builder.GetService<TransientClass>().GetHashCode().ToString()}");
             });
            Console.WriteLine("Press A Key");
            Console.ReadKey();
        }
    }
}
