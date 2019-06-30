using System;
using System.Threading.Tasks;

namespace AsynchronousProgrammingTest
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Starting async method 1...");

			var a = Method1Async();

			Console.WriteLine("Awaiting async method 1...");

			await a;

			Console.WriteLine("Async method 1 finished runnning.");
		}

		static async Task<int> Method1Async()
		{
			Console.WriteLine("This is async method 1! I'm doing stuff...");
			await Task.Delay(5000);
			return 1;
		}
	}
}
