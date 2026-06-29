using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace DroneRacer.Classes;

public class TaskCompletionDroneCounter()
{
    
    public static Task CompletionDroneCounter()
    {
        var masterTsc = new TaskCompletionSource<bool>();
        
        var counter1    = new Drone("Kathryn"  ,  50, 20,  80);
        var counter2    = new Drone("Billy"    ,  80,  0, 250);
        var counter3    = new Drone("Excelsior",  30, 20, 500);

        var task1       = DroneCounter(counter1);
        var task2       = DroneCounter(counter2);
        var task3       = DroneCounter(counter3);

        Task.WhenAll(task1, task2, task3).ContinueWith(allTasks =>
        {
            if (allTasks.IsFaulted)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                masterTsc.SetException(allTasks.Exception);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("All flights completed");
                masterTsc.SetResult(true);
                Console.ResetColor();
            }
        });
        return masterTsc.Task;
    }
    
    private static Task DroneCounter(Drone id)
    {
        var tsc = new TaskCompletionSource();

        Task.Run(() =>
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{id.Name} ");
                Console.ResetColor();
                Console.WriteLine("is starting it's flight");
                DroneTaskAwaiter(id, tsc);
            }
            catch (Exception ex)
            {
                tsc.SetException(ex);
            }
        });
        return tsc.Task;
    }

    private static void DroneTaskAwaiter(Drone id, TaskCompletionSource tsc)
    {
        int currentCount = 0;

        void Count()
        {
            try
            {
                if (currentCount <= id.Target)
                {
                    var delayTask = Task.Delay(id.Speed);
                    Console.WriteLine($"{id.Name} has flown {currentCount} / {id.Target} meters");

                    var awaiter = delayTask.GetAwaiter();
                    awaiter.OnCompleted(() =>
                    {
                        Console.WriteLine($"{id.Name} resuming after delay");
                        currentCount++;

                        Count();
                    });
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{id.Name} has reached it's target");
                    Console.ResetColor();
                    tsc.SetResult();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{id.Name} encountered");
                tsc.SetException(ex);
            }
        }
        Count();
    }
}

