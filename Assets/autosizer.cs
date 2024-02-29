using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class autosizer : MonoBehaviour
{
    [SerializeField] private float defaultScreenSize;
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = canvas.GetComponent<RectTransform>().rect.width;
        for (int childCount = 0; childCount < this.transform.childCount; childCount++)
        {
            Transform currentChild = this.transform.GetChild(childCount);
            if (currentChild.name == "Square")
            {
                currentChild.GetComponent<RectTransform>().localScale = new Vector3(screenWidth, currentChild.GetComponent<RectTransform>().localScale.y, currentChild.GetComponent<RectTransform>().localScale.z);
            }
            else if(currentChild.GetComponents<TextMeshProUGUI>().Length > 0)
            {
                currentChild.GetComponent<RectTransform>().sizeDelta = new Vector2(screenWidth, currentChild.GetComponent<RectTransform>().rect.height);
            }
            else if (currentChild.tag == "Option")
            {
                float scaleMultiplier = screenWidth / defaultScreenSize;
                currentChild.GetComponent<RectTransform>().localScale = new Vector3(currentChild.GetComponent<RectTransform>().localScale.y, currentChild.GetComponent<RectTransform>().localScale.y, currentChild.GetComponent<RectTransform>().localScale.z) * scaleMultiplier;
                currentChild.GetComponent<RectTransform>().position = new Vector3(currentChild.GetComponent<RectTransform>().position.x * scaleMultiplier, currentChild.GetComponent<RectTransform>().position.y, currentChild.GetComponent<RectTransform>().position.z);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
