using StudySchedule.Logic;

namespace StudySchedule.Data;

public class LessonRepository : ILessonRepository
{
    private readonly List<Lesson> _lessons = new()
    {
        new Lesson { Id = 1, Subject = "Математика", Room = "212" },
        new Lesson { Id = 2, Subject = "Физика", Room = "212" },
        new Lesson { Id = 3, Subject = "Химия", Room = "305" }
    };

    public List<Lesson> GetAll()
    {
        return _lessons;
    }

    public void Add(Lesson item)
    {
        _lessons.Add(item);
    }
}

