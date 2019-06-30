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

		// compute PI using Taylor series: PI/4 = 1 - 1/3 + 1/5 - 1/7 + 1/9 - ... 
		static void computePI()
		{
			double quarterPI = 1;
			double taylorTerm;

			for (int i = 0; i < 1E9; i++)
			{
				taylorTerm = (double)1 / (i * 2 + 3);

				if (i % 2 == 0) taylorTerm = -taylorTerm;

				quarterPI += taylorTerm;
			}

			Console.WriteLine($"Computed PI: { quarterPI * 4 }; Math.PI: { Math.PI }");
		}
	}
}
