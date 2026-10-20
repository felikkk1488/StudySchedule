using StudySchedule.Data;
using StudySchedule.Logic;

string jsonPath = Path.Combine(AppContext.BaseDirectory, "lessons.json");
string xmlPath = Path.Combine(AppContext.BaseDirectory, "lessons.xml");

string kind = args.Length > 0 ? args[0] : "json";

ILessonRepository repository = kind switch
{
    "xml" => new XmlLessonRepository(xmlPath),
    "memory" => new LessonRepository(),
    _ => new JsonLessonRepository(jsonPath)
};

Console.WriteLine($"Хранилище: {kind}");

var service = new LessonService(repository);

Console.Write("Тема нового занятия: ");
string subject = Console.ReadLine() ?? "";
Console.Write("Аудитория нового занятия: ");
string newRoom = Console.ReadLine() ?? "";
service.AddLesson(subject, newRoom);

Console.WriteLine("Отобранные записи:");

foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Subject}");
}

Console.Write("Аудитория для поиска: ");
string room = Console.ReadLine() ?? "";

Console.WriteLine($"Занятия в аудитории {room}:");

foreach (var item in service.GetByRoom(room))
{
    Console.WriteLine($"{item.Id}: {item.Subject}");
}