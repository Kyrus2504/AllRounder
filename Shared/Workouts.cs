namespace Shared;

public class Workouts
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Type {get; set;}
    
    public int Duration {get; set;}

    public int ExpectCalBurned {get; set;}

    public List<string> ExerciseList {get; set;}

}