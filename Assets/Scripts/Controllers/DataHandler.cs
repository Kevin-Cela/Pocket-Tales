using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler<T>
{
    private T dataToHandle;
    private string fullPath;
    public DataHandler(string directoryName,string fileName)
    {
        this.fullPath = Path.Combine(Application.persistentDataPath, directoryName, fileName);
    }
    public void saveData(T dataToSave)
    {

    }
    public T LoadData()
    {
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                dataToHandle = JsonUtility.FromJson<T>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        return dataToHandle;
    }
}
