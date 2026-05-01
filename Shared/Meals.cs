namespace Shared;

public class Meal
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public int Calories {get; set;}
    public double Fat {get; set;}
    public double Carbs {get; set;}
    public double Protein {get; set;}

    public DateTime LastEaten {get; set;}

}