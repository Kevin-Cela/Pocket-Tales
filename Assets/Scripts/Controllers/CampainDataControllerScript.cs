using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;

public class CampainDataController : MonoBehaviour
{
    [Header("Save Configuration Properties")]
    [SerializeField] private string saveFileName;

    private CampainData data;
    public static CampainDataController Instance { get; private set; }

    private int nextScene = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("An error has occured, more than one instance found!");
        }
        Instance = this;
    }
    private void LoadAllScenesIntoArray()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, saveFileName);
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
                Debug.Log(dataToLoad);
                data = JsonUtility.FromJson<CampainData>(dataToLoad);
                Debug.Log(data.Scenes[0].Configuration.NextSceneId);
            } catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
    private void LoadScene(int nextScene)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, saveFileName);

    }
    private void Save()
    {
        //try
        //{
        //    Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(Application.persistentDataPath, saveFileName)));

        //    using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, saveFileName), FileMode.Create))
        //    {
        //        using (StreamWriter writer = new StreamWriter(stream))
        //        {
        //            string data = "";
        //            data = JsonUtility.ToJson(data);
        //            writer.Write(data);
        //        }
        //    }
        //} catch (Exception e)
        //{
        //    Debug.LogError(e);
        //}
        
    }
    private void Start()
    {
        LoadAllScenesIntoArray();
        LoadScene(nextScene);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
