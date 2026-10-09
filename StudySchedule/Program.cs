using StudySchedule.Data;
using StudySchedule.Logic;

ILessonRepository repository = new LessonRepository();

var service = new LessonService(repository);

Console.WriteLine("Отобранные записи:");

foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Subject}");
}
