using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionSceneController : MonoBehaviour, IDataHandler<SceneData>
{
    private SceneData scene;
    private int something;
    public void LoadData(SceneData gameData)
    {
        scene = gameData;
        if(scene.Type == "Interactive")
        {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
