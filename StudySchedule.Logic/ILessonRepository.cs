namespace StudySchedule.Logic;

public interface ILessonRepository
{
    List<Lesson> GetAll();
    void Add(Lesson item);
}
