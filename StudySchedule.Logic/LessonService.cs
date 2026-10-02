using StudySchedule.Data;

namespace StudySchedule.Logic;

public class LessonService
{
    private readonly LessonRepository _repository = new();

    public List<Lesson> GetImportant()
    {
        return _repository.GetAll()
            .Where(item => item.Room == "212")
            .ToList();
    }
}
