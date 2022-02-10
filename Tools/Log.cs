namespace Tools;


public sealed class Log
{
    private static Log? _instance = null;
    private string _path;
    private static object _protect = new object();

    public static Log GetInstance(string path)
    {
        // while one thread is working with this attribute, no other thread can work with it
        lock (_protect)
        {
            if (_instance == null)
            {
                return new Log(path);
            }
        }

        return _instance;
    }

    public static Log Instance
    {
        get { return _instance; }
    }

    private Log(string path)
    {
        _path = path;
    }
    public void Save(string message)
    {
        File.AppendAllText(_path, message + Environment.NewLine);
    }
}