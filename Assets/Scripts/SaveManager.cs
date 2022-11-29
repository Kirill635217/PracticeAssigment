using System.IO;

public class SaveManager
{
    public static void SaveAsTextFile(string path, string fileName, string text)
    {
        if (path[path.Length - 1] != '/')
            path += "/";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        var name = path + fileName + ".txt";
        File.WriteAllText(name, text);
    }
}
