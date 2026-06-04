using System.Runtime.CompilerServices;

namespace DroneRacer.Classes;

public static class AsyncDroneCounter
{
    public static async Task AsyncTimer()
    {
        var drone1 = new Drone("Drone 1", 50,  10, 100);
        var drone2 = new Drone("Drone 2", 20,   0, 300);
        var drone3 = new Drone("Drone 3", 60, 200, 250);
    
        var task1 = ASyncTravel(drone1);
        var task2 = ASyncTravel(drone2);
        var task3 = ASyncTravel(drone3);

        await Task.WhenAll(task1, task2, task3);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All drones have reached their target");
        Console.ResetColor();
    }

    private static async Task ASyncTravel(Drone id)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Async drone {id.Name} is starting it's flight");
        Console.ResetColor();

        for (int i = id.Start; i <= id.Target; i++)
        {
            await Task.Delay(id.Speed);
            Console.WriteLine($"{id.Name} has traveled {i} out of {id.Target} meters");
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Async task {id.Name} has completed it's flight");
        Console.ResetColor();
    }

}