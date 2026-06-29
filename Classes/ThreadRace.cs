

namespace DroneRacer.Classes;

public class DroneThreads
{
    public static void DroneThread()
    {
        var dthread1 = new Drone ("Billy-Bob",   40, 10, 150);
        var thread1  = new Thread(DroneThreader);
        thread1.Start            (dthread1);
        
        var dthread2 = new Drone ("Are-Kjetil", 200,  0,  50);
        var thread2  = new Thread(DroneThreader);
        thread2.Start            (dthread2);
        
        var dthread3 = new Drone ("Flipper",     10, 10,  40);
        var thread3  = new Thread(DroneThreader);
        thread3.Start            (dthread3);

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All drones finished their flights");
        Console.ResetColor();
    }

    private static void DroneThreader(object? id)
    {
        var dCounter = (Drone) id!;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{dCounter.Name} ");
        Console.WriteLine("has started it's flight");
        Console.ResetColor();

        for (int i = dCounter.Start; i < dCounter.Target; i++)
        {
            Thread.Sleep(dCounter.Speed);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{dCounter.Name} ");
            Console.ResetColor();
            Console.WriteLine($"has flown {i} out of {dCounter.Target - dCounter.Start} meters");
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{dCounter.Name} completed it's flight");
        Console.ResetColor();
    }
}

//Asynkront og rart. Alt kommer hulter til bulter