using System.Text.Json;
using System.Text.Encodings.Web;
using StudySchedule.Logic;

namespace StudySchedule.Data;

public class JsonLessonRepository : ILessonRepository
{
    private readonly string _path;

    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public JsonLessonRepository(string path)
    {
        _path = path;
    }

    public List<Lesson> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Lesson>();
        }

        string text = File.ReadAllText(_path);

        try
        {
            return JsonSerializer.Deserialize<List<Lesson>>(text) ?? new List<Lesson>();
        }
        catch (JsonException)
        {
            return new List<Lesson>();
        }
    }

    public void Add(Lesson item)
    {
        List<Lesson> items = GetAll();
        items.Add(item);

        string text = JsonSerializer.Serialize(items, _options);
        File.WriteAllText(_path, text);
    }
}


