namespace DelegatesAndEvents;

public class FileFoundArgs : EventArgs
{
    public string FoundFile { get; }
    public bool CancelRequested { get; set; }

    public FileFoundArgs(string fileName) => FoundFile = fileName;
}

public class FileSearcher
{
    public event EventHandler<FileFoundArgs>? FileFound;

    public void Search(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            FileFoundArgs args = RaiseFileFound(file);
            if (args.CancelRequested)
            {
                break;
            }
        }
    }

    private FileFoundArgs RaiseFileFound(string file)
    {
        var args = new FileFoundArgs(file);
        FileFound?.Invoke(this, args);
        return args;
    }
}