using System.Reflection.Metadata.Ecma335;

namespace DroneRacer.Classes;

public class Maps
{
    public void DroneList()
    {
        Drone Drone1 = new( speed:  10, start:  20,  target:  250);
        Drone Drone2 = new( speed:  50, start:   0,  target:  550);
        Drone Drone3 = new( speed: 250, start:  35,  target:  690);
        Drone Drone4 = new( speed:  70, start:   5,  target:  350);
        Drone Drone5 = new( speed:  50, start:  50,  target:  600);
        Drone Drone6 = new( speed: 800, start:  30,  target: 8250);
        Drone Drone7 = new( speed: 300, start: 590,  target: 4150);
        Console.WriteLine($"{Drone1.Speed}");
    }

    
}