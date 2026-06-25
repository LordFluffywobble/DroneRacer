using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DroneRacer.Classes;

namespace DroneRacer;

class Program
{
       static async Task Main(string[] args)
    {
        await AsyncDroneCounter.AsyncTimer(); 
        await TaskCompletionDroneCounter.CompletionDroneCounter();
    }
}

       