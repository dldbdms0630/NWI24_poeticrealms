using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material background;
    
    // Start is called before the first frame update
    void Start()
    {
        background.color = Color.red;
        RenderSettings.skybox.SetColor("_Tint", Color.blue);
        Debug.Log("SETTING");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
