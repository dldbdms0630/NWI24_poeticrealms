using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Reference to the skybox material
    public Material skyboxMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial skybox material
        RenderSettings.skybox = skyboxMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Change tint color over time
        float time = Mathf.PingPong(Time.time, 1.0f);
        Color tintColor = Color.Lerp(Color.blue, Color.red, time);
        RenderSettings.skybox.SetColor("_Tint", tintColor);
    }

    // Method to set tint color
    public void SetTintColor(Color color)
    {
        RenderSettings.skybox.SetColor("_Tint", color);
    }
}
