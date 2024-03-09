using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class TextSceneController : MonoBehaviour, IDataHandler<SceneData>
{
    private SceneData scene;
    private TextMeshProUGUI textDisplayer;
    private float timestart;
    private int i;
    private int length=1;
    private bool startTextTransition;
    private bool startTimer;
    public void LoadData(SceneData gameData)
    {
        scene = gameData;
        i = 0;
        timestart = Time.timeSinceLevelLoad;
        Debug.Log(timestart);
        length = scene.Description.Length;
        Debug.Log(0.08 - (length / 100.0 > 1 ? 1 : length / 100.0) * 0.03);
        startTextTransition = true;
        startTimer = true;
    }

    public void SaveData(SceneData gameData)
    {
        //
    }
    private void ChangeDisplayText(double timeStep)
    {
        float timeDifference = Time.timeSinceLevelLoad - timestart;
        if ((textDisplayer.text != null || textDisplayer.text != "") && i==0)
        {
            textDisplayer.text = "";
        }
        if(i<length)
        {
            if (timeDifference >= timeStep)
            {
                textDisplayer.text += scene.Description[i];
                i++;
                timestart = Time.timeSinceLevelLoad;
            }
        }
        else
        {
            startTextTransition = false;
        }
    }
    private void StartSceneTimer(float timeTotal)
    {
        float timeDifference = Time.timeSinceLevelLoad - timestart;
        if (timeDifference >= timeTotal)
        {
            if(scene.Type == "Story")
            {
                CampaignDataController.Instance.LoadScene(scene.Configuration.NextSceneId);
            }
            else if(scene.Type == "Interactive")
            {
                CampaignDataController.Instance.LoadScene(2);
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        textDisplayer = this.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTextTransition == true)
        {
            ChangeDisplayText(0.08 - (length / 100.0 > 1 ? 1 : length / 100.0) * 0.03);
        }
        else if(startTimer == true)
        {
            StartSceneTimer(15);
        }
        
    }
}
