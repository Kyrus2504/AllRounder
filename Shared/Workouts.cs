namespace Shared;

public class Workout
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Type {get; set;} = string.Empty;
    
    public int Duration {get; set;}

    public int ExpectCalBurned {get; set;}

    public DateTime ScheduledFor {get; set;}
    public string? Notes {get; set;}

}