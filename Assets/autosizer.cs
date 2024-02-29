using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autosizer : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = canvas.GetComponent<RectTransform>().rect.width;
        this.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(screenWidth, this.GetComponentInChildren<RectTransform>().rect.height);
        //this.transform.localScale = new Vector3(screenWidth, this.transform.localScale.y, this.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
