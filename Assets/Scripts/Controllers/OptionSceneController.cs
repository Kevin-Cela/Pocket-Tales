using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionSceneController : MonoBehaviour, IDataHandler<SceneData>
{
    private SceneData scene;
    [SerializeField] private float XScreenSize;
    [SerializeField] private float YScreenSize;
    [SerializeField] private int numberOfColumns;
    [SerializeField] private GameObject optionPrefab;
    [SerializeField] private float defaultNumberOfColumns;
    [SerializeField] private float defaultNumberOfRows;

    public void LoadData(SceneData gameData)
    {
        scene = gameData;
        if(scene.Type == "Interactive")
        {
            AutoRenderOptions(gameData);
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(SceneData gameData)
    {
        //
    }
    public void AutoRenderOptions(SceneData gameData)
    {
        int numberOfOptions = gameData.Configuration.Options.Length;
        int currentOption = 0;
        int numberOfRows = (int)Math.Ceiling((numberOfOptions / (numberOfColumns * 1.0)));
        double normalizedYDifference = 1 / (numberOfRows * 1.0);
        double normalizedXDifference = 1 / (numberOfColumns*1.0);
        foreach (Option option in gameData.Configuration.Options)
        {
            int currentRow = (int)(currentOption / (numberOfColumns * 1.0));
            double YCoordinateFactor = 0.5 - (normalizedYDifference*(currentRow + 1) - normalizedYDifference/2) ;
            int currentColumn = currentOption % numberOfColumns;
            if( currentRow == numberOfRows - 1 && numberOfOptions % numberOfColumns != 0 )
            {
                normalizedXDifference = 1 / ((numberOfOptions % numberOfColumns) * 1.0);
            }
            double XCoordinateFactor = (normalizedXDifference * (currentColumn + 1) - normalizedXDifference / 2) - 0.5;
            
            
            GameObject newLoadedOption = Instantiate(optionPrefab, new Vector3(((float)(XScreenSize*XCoordinateFactor)), ((float)(YScreenSize * YCoordinateFactor)), 0), Quaternion.identity);
            newLoadedOption.transform.SetParent(this.transform, false);
            newLoadedOption.GetComponentInChildren<TextMeshProUGUI>().text = gameData.Configuration.Options[currentOption].Text;


            if ( numberOfRows > defaultNumberOfRows || numberOfColumns > defaultNumberOfColumns)
            {
                float scaleMultiplierX = 1;
                float scaleMultiplierY = 1;
                if ( numberOfColumns > defaultNumberOfColumns )
                {
                    scaleMultiplierX = (float)(defaultNumberOfColumns / (numberOfColumns * 1.0));
                }
                if ( numberOfRows > defaultNumberOfRows)
                {
                    scaleMultiplierY = (float)(defaultNumberOfRows / (numberOfRows * 1.0));
                }
                
                float scaleMultiplier = scaleMultiplierX * scaleMultiplierY;
                Debug.Log(scaleMultiplier);
                newLoadedOption.transform.localScale = new Vector3(newLoadedOption.transform.localScale.x, newLoadedOption.transform.localScale.y, newLoadedOption.transform.localScale.z) * scaleMultiplier;
                newLoadedOption.transform.position = new Vector3(newLoadedOption.transform.position.x, newLoadedOption.transform.position.y, newLoadedOption.transform.position.z);
            }
            
            currentOption++;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
