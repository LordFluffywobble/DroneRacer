namespace DroneRacer.Classes;

public class Drone(string name, int speed, int start, int target)
{
    internal string Name    {get; set;} = name;
    internal int    Speed   {get; set;} = speed;
    internal int    Start   {get; set;} = start;
    internal int    Target  {get; set;} = target;
}

