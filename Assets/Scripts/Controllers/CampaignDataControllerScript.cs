using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class CampaignDataController : MonoBehaviour
{
    [Header("Save Configuration Properties")]
    [SerializeField] private string directoryName;
    [SerializeField] private string fileName;
    private DataHandler<CampaignData> campaignDataHandler;
    private List<IDataHandler<SceneData>> sceneDataHandleObjects;
    private CampaignData selectedCampaign;
    private int nextScene = 0;
    public static CampaignDataController Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("An error has occured, more than one instance found!");
        }
        Instance = this;
        
    }
    private void LoadCampaignData()
    {

        selectedCampaign = campaignDataHandler.LoadData();
        Debug.Log(selectedCampaign.Scenes[0].Configuration.NextSceneId);
            
    }
    public void LoadScene(int nextScene)
    {
        foreach(IDataHandler<SceneData> sceneDataHandler  in sceneDataHandleObjects)
        {
            sceneDataHandler.LoadData(selectedCampaign.Scenes[nextScene]);
        }
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
        campaignDataHandler = new DataHandler<CampaignData>(directoryName, fileName);
        LoadCampaignData();
        this.sceneDataHandleObjects = FindAllDataHandleObjects();
        LoadScene(nextScene);
    }

    private List<IDataHandler<SceneData>> FindAllDataHandleObjects()
    {
        IEnumerable<IDataHandler<SceneData>> sceneDataHandlers = FindObjectsOfType<MonoBehaviour>().OfType<IDataHandler<SceneData>>();

        return new List<IDataHandler<SceneData>>(sceneDataHandlers);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
