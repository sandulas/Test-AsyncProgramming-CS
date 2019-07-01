using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgrammingTest
{
	class Program
	{
		static async Task Main(string[] args)
		{
			await method1BatchV2Async(20);
			//Console.ReadLine();
			//Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Starting async methods...");

			//var asyncTask1 = method1Async(1);
			//var asyncTask2 = method1Async(2);
			//var asyncTask3 = method1Async(3);

			//Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Awaiting async methods...");
			////Console.ReadLine();

			//await asyncTask1;
			//await asyncTask2;
			//await asyncTask3;

			//Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Async methods finished runnning.");
		}

		static async Task method1BatchV1Async(int count)
		{
			for (int i = 0; i < count; i++)
			{
				await method1Async(i);
			}
		}

		static async Task method1BatchV2Async(int count)
		{
			var tasks = new Task[count];

			for (int i = 0; i < count; i++)
			{
				tasks[i] = method1Async(i);
			}
			for (int i = 0; i < count; i++)
			{
				await tasks[i];
			}
		}

		static async Task<string> method1Async(int i)
		{
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: This is async method { i }! I'm doing stuff...");

			HttpClient httpClient = new HttpClient();
			var request = await httpClient.GetAsync("http://google.com");
			var download = await request.Content.ReadAsStringAsync();

			//await Task.Delay(5000);

			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: This is async method { i }! I'm done!");
			return download;
		}

		static void computePIBatch(int count)
		{
			for (int i = 0; i < count; i++)
			{
				computePI();
			}
		}

		static async Task computePIBatchAsync(int count)
		{
			//var tasks = new Task[count];
			for (int i = 0; i < count; i++)
			{
				await Task.Run(() => computePI());
			}
		}

		// compute PI using Taylor series: PI/4 = 1 - 1/3 + 1/5 - 1/7 + 1/9 - ... 
		static double computePI()
		{
			double quarterPI = 1;
			double taylorTerm;

			for (int i = 0; i < 1E9; i++)
			{
				taylorTerm = (double)1 / (i * 2 + 3);

				if (i % 2 == 0) taylorTerm = -taylorTerm;

				quarterPI += taylorTerm;
			}

			return quarterPI * 4;
			//Console.WriteLine($"Computed PI: { quarterPI * 4 }; Math.PI: { Math.PI }");
		}
	}
}
