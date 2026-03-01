using System.Text.Json;
using GymMemberManager.Models;

namespace GymMemberManager.Repositories;

public sealed class JsonMemberRepository : IMemberRepository
{
    private readonly string _filePath;
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    public JsonMemberRepository(string filePath)
    {
        _filePath = filePath;
    }
    public IReadOnlyList<Member> Load()
    {
        if (!File.Exists(_filePath))
            return Array.Empty<Member>();

        var json = File.ReadAllText(_filePath);
        if (string.IsNullOrWhiteSpace(json))
            return Array.Empty<Member>();

        var members = JsonSerializer.Deserialize<List<Member>>(json, _options);
        return members ?? new List<Member>();
    }

    public void Save(IReadOnlyList<Member> members)
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);

        var json = JsonSerializer.Serialize(members, _options);
        File.WriteAllText(_filePath, json);
    }
}