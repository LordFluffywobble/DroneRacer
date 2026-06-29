using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DroneRacer.Classes;

namespace DroneRacer;

class Program
{
       static async Task Main(string[] args)
    {
        Console.WriteLine("Press A for the threaded drone version");
        Console.WriteLine("Press B for the TaskCompletion drone version");
        Console.WriteLine("Press C for the Async drone version");

        ConsoleKeyInfo input = Console.ReadKey(true);
        if (input.Key == ConsoleKey.A)  {   DroneThreads.DroneThread();  }
        
        if (input.Key == ConsoleKey.B)  { await TaskCompletionDroneCounter.CompletionDroneCounter(); }

        if (input.Key == ConsoleKey.C)  { await AsyncDroneCounter.AsyncTimer(); }
    }
}

       