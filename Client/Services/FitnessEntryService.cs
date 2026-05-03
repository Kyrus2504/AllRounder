using System.Net.Http.Json;
using Shared;
public class FitnessEntryService
{
    private readonly HttpClient _http;

    public FitnessEntryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<FitnessEntry>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<FitnessEntry>>("api/FitnessEntries") ?? new();

    public async Task<FitnessEntry?> GetByIdAsync(int id) =>
        await _http.GetFromJsonAsync<FitnessEntry>($"api/FitnessEntries/{id}");

    public async Task CreateAsync(FitnessEntry fitnessEntry) =>
        await _http.PostAsJsonAsync("api/FitnessEntries", fitnessEntry);

    public async Task UpdateAsync(int id, FitnessEntry fitnessEntry) =>
        await _http.PutAsJsonAsync($"api/FitnessEntries/{id}", fitnessEntry);

    public async Task DeleteAsync(int id) =>
        await _http.DeleteAsync($"api/FitnessEntries/{id}");
}