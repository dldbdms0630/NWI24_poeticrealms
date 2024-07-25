using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurtObjManager : MonoBehaviour
{
    /* 
     * All public GameObjects are to be assigned in Inspector. These are all
     * pieced together by the poems! Each method is called with the corresponding line.
    */
    public GameObject tvScreen; 
    public GameObject firstLight;
    public Material topLightMaterial;
    public GameObject titleText;
    // public GameObject frontSofaPortal;

    public void DisableTitle()
    {
        titleText.SetActive(false);
    }

    public void EnableTV()
    {
        tvScreen.SetActive(true);
        firstLight.SetActive(true);
        topLightMaterial.EnableKeyword("_EMISSION");
        topLightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;


//         mat.DisableKeyword("_EMISSION");
// mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
// mat.SetColor("_EmissionColor", Color.black);

        
    }

    // public void DisableObjects()
    // {
    //     cubeForScreen.SetActive(false);
    //     lightObject.SetActive(false);
    // }
}
