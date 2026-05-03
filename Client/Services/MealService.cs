using System.Net.Http.Json;
using Shared;
public class MealService
{
    //initialise constructors
    private readonly HttpClient _http;

    public MealService(HttpClient http)
    {
        _http = http;
    }

    //get all function
    public async Task<List<Meal>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<Meal>>("api/Meals") ?? new();

    //get by id function
    public async Task<Meal?> GetByIdAsync(int id) =>
        await _http.GetFromJsonAsync<Meal>($"api/Meals/{id}");

    //create item function
    public async Task CreateAsync(Meal meal) =>
        await _http.PostAsJsonAsync("api/Meals", meal);

    //Update item function
    public async Task UpdateAsync(int id, Meal meal) =>
        await _http.PutAsJsonAsync($"api/Meals/{id}", meal);

    //delete item function
    public async Task DeleteAsync(int id) =>
        await _http.DeleteAsync($"api/Meals/{id}");
}