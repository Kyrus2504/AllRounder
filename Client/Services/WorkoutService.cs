using System.Net.Http.Json;
using Shared;
public class WorkoutService
{
    private readonly HttpClient _http;

    public WorkoutService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Workout>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<Workout>>("api/Workouts") ?? new();

    public async Task<Workout?> GetByIdAsync(int id) =>
        await _http.GetFromJsonAsync<Workout>($"api/Workouts/{id}");

    public async Task CreateAsync(Workout workout) =>
        await _http.PostAsJsonAsync("api/Workouts", workout);

    public async Task UpdateAsync(int id, Workout workout) =>
        await _http.PutAsJsonAsync($"api/Workouts/{id}", workout);

    public async Task DeleteAsync(int id) =>
        await _http.DeleteAsync($"api/Workouts/{id}");
}