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
        var counter2    = new Drone("Billy"    ,  80,  0, 400);
        var counter3    = new Drone("Excelsior", 300, 20, 900);

        var task1       = DroneCounter(counter1);
        var task2       = DroneCounter(counter2);
        var task3       = DroneCounter(counter3);
    }
    
    private static Task DroneCounter(Drone id)
    {
        
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
                    Console.WriteLine($"{id.Name} has reached it's target");
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

