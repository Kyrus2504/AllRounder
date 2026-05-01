namespace Shared;

public class Meal
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int Calories {get; set;}
    public double Fat {get; set;}
    public double Farbs {get; set;}
    public double Frotein {get; set;}

    public DateTime LastEaten {get; set;}

    public List<string> Ingredients {get; set;}

}