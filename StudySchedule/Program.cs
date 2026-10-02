using StudySchedule.Logic;

var service = new LessonService();

Console.WriteLine("Отобранные записи:");

foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Subject}");
}
