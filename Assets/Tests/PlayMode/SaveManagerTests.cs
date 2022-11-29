using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class SaveManagerTests
{
    [Test]
    public void SaveToTextFile()
    {
        var directory = Application.streamingAssetsPath + "/Tests/";
        if (Directory.Exists(directory))
            directory += $"{Random.Range(0, 100)}/";
        var fileName = "SaveToTextFileTest";
        var content = "test";
        SaveManager.SaveAsTextFile(directory, fileName, content);
        Assert.AreEqual(true, Directory.Exists(directory));
        var files = Directory.GetFiles(directory);
        Debug.Log(files[0]);
        Assert.AreEqual(1, files.Length);
        Assert.AreEqual(files[0], directory + fileName + ".txt");
        Assert.AreEqual(content, File.ReadAllText(directory + fileName + ".txt"));
        FileUtil.DeleteFileOrDirectory(directory);
    }
}
