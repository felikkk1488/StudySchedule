namespace StudySchedule.Logic;

public class LessonService
{
    private readonly ILessonRepository _repository;

    public LessonService(ILessonRepository repository)
    {
        _repository = repository;
    }

    public List<Lesson> GetImportant()
    {
        return _repository.GetAll()
            .Where(item => item.Room == "212")
            .ToList();
    }

    public void AddLesson(string subject, string room)
    {
        if (string.IsNullOrEmpty(subject))
        {
            return;
        }

        int nextId = _repository.GetAll().Count + 1;

        _repository.Add(new Lesson
        {
            Id = nextId,
            Subject = subject,
            Room = room
        });
    }

    public List<Lesson> GetByRoom(string room)
    {
        return _repository.GetAll()
            .Where(item => item.Room == room)
            .ToList();
    }


}

