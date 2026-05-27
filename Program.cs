using DroneRacer.Classes;

namespace DroneRacer;

class Program
{


    static void Main(string[] args)
    {
        ActiveDrones aDrones = new();
        List<Drone> drones = aDrones.DroneList();
        foreach (Drone drone in drones)
        {
            Console.WriteLine($"{drone.Start}, {drone.Speed}, {drone.Target}");
        }
    }

}
