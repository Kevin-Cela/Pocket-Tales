using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autosizer : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(canvas.GetComponent<RectTransform>().rect.width, this.transform.localScale.y, this.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
