using StudySchedule.Logic;

namespace StudySchedule.Data;

public class DemoLessonRepository : ILessonRepository
{
    public List<Lesson> GetAll()
    {
        return new List<Lesson>()
        {
            new Lesson { Id = 100, Subject = "Демонстрационное занятие", Room = "212" },
            new Lesson { Id = 101, Subject = "Демо: не попадёт в отбор", Room = "101" }
        };
    }
    public void Add(Lesson item)
    {
        // Демонстрационное хранилище доступно только для чтения
    }
}
