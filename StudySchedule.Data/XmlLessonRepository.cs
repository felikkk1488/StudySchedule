using System.Xml.Serialization;
using StudySchedule.Logic;

namespace StudySchedule.Data;

public class XmlLessonRepository : ILessonRepository
{
    private readonly string _path;

    private readonly XmlSerializer _serializer = new(typeof(List<Lesson>));

    public XmlLessonRepository(string path)
    {
        _path = path;
    }

    public List<Lesson> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Lesson>();
        }

        using var reader = new StreamReader(_path);
        return _serializer.Deserialize(reader) as List<Lesson> ?? new List<Lesson>();
    }

    public void Add(Lesson item)
    {
        List<Lesson> items = GetAll();
        items.Add(item);

        using var writer = new StreamWriter(_path);
        _serializer.Serialize(writer, items);
    }
}

