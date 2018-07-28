using System;
using System.Threading.Tasks;

namespace ApiCaller
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var proxy = new ApiProxy();

            var results = await proxy.GetValues();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
