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
}