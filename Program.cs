using DelegatesAndEvents;

// Обобщённая функция расширения, находящая и возвращающая максимальный элемент коллекции
var strArray = new[] { "124.6", "777.7", "56.7", "Test", "-10" };
string valueMax = strArray.GetMax(Convertor.StringToDouble) ?? string.Empty;

Console.WriteLine($"Максимальный элемент коллекции: {valueMax} \n");


// Класс обходит каталог файлов и выдаёт событие при нахождении каждого файла
var fileLister = new FileSearcher();
int filesFound = 0;

EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
{   
    filesFound++;
};

fileLister.FileFound += onFileFound;
fileLister.Search("C:\\", "*.*");

Console.WriteLine($"Найдено файлов: {filesFound}");
fileLister.FileFound -= onFileFound;

// Возможность отмены дальнейшего поиска из обработчика
EventHandler<FileFoundArgs> onFirstFileFound = (sender, eventArgs) =>
{
    Console.WriteLine($"Первый найденный файл: {eventArgs.FoundFile}");
    eventArgs.CancelRequested = true;
};
fileLister.FileFound += onFirstFileFound;
fileLister.Search("C:\\", "*.*");
