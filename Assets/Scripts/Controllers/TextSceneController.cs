using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class TextSceneController : MonoBehaviour, IDataHandler<SceneData>
{
    private SceneData scene;
    private TextMeshProUGUI textDisplayer;
    private float timeStart;
    private int indexOfText;
    private int lengthOfText=1;
    private bool startTextTransition;
    private bool startTimer;
    public void LoadData(SceneData gameData)
    {
        scene = gameData;
        indexOfText = 0;
        timeStart = Time.timeSinceLevelLoad;
        lengthOfText = scene.Description.Length;
        //Debug.Log(0.08 - (lengthOfText / 100.0 > 1 ? 1 : lengthOfText / 100.0) * 0.03);
        startTextTransition = true;
        startTimer = true;
    }

    public void SaveData(SceneData gameData)
    {
        //
    }
    private void ChangeDisplayText(double timeStep)
    {
        float timeDifference = Time.timeSinceLevelLoad - timeStart;
        if ((textDisplayer.text != null || textDisplayer.text != "") && indexOfText==0)
        {
            textDisplayer.text = "";
        }
        if(indexOfText<lengthOfText)
        {
            if (timeDifference >= timeStep)
            {
                textDisplayer.text += scene.Description[indexOfText];
                indexOfText++;
                timeStart = Time.timeSinceLevelLoad;
            }
        }
        else
        {
            startTextTransition = false;
        }
    }
    private void StartSceneTimer(float timeTotal)
    {
        float timeDifference = Time.timeSinceLevelLoad - timeStart;
        if (timeDifference >= timeTotal)
        {
            startTimer = false;

            if (scene.Type == "Story")
            {
                CampaignDataController.Instance.LoadScene(scene.Configuration.NextSceneId);
            }
            else if(scene.Type == "Interactive")
            {
                //TODO
                CampaignDataController.Instance.LoadScene(2);
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        indexOfText = 0;
        textDisplayer = this.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTextTransition == true)
        {
            ChangeDisplayText(0.08 - (lengthOfText / 100.0 > 1 ? 1 : lengthOfText / 100.0) * 0.03);
        }
        else if(startTimer == true)
        {
            StartSceneTimer(3);
        }
        
    }
}
