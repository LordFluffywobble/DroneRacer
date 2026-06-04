using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DroneRacer.Classes;

namespace DroneRacer;

class Program
{
       static async Task Main(string[] args)
    {
        await AsyncDroneCounter.AsyncTimer(); 
    }
}

        
        
        
        // ActiveDrones aDrones = new();
        // List<Drone> drones = aDrones.DroneList();

        // Console.ForegroundColor = ConsoleColor.DarkBlue;
        // Console.WriteLine($"{"Start", -15} {"Speed", -15} {"Target", -15} {"Time Elapsed", -15}\n");
        // foreach (Drone drone in drones)
        // {
        //     Console.ForegroundColor = ConsoleColor.DarkYellow;
        //     Console.WriteLine($"{drone.Start, -15} {drone.Speed, -15} {drone.Target, -15} {(drone.Target - drone.Start) / drone.Speed, -15}");
        // }
        // Console.ResetColor();
       