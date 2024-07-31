using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextNoise : MonoBehaviour
{
    TMP_Text textMesh;

    Mesh mesh;

    Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    // void Update()
    // {
    //     textMesh.ForceMeshUpdate();
    //     mesh = textMesh.mesh;
    //     vertices = mesh.vertices;

    //     for (int i = 0; i < vertices.Length; i++)
    //     {
    //         Vector3 offset = Wobble(Time.time + i);

    //         vertices[i] = vertices[i] + offset;
    //     }

    //     mesh.vertices = vertices;
    //     // textMesh.canvasRenderer.SetMesh(mesh);
    //     textMesh.mesh = mesh;

    // }


    void Update()
{
    textMesh.ForceMeshUpdate();
    var textInfo = textMesh.textInfo;
    var vertices = textInfo.meshInfo[0].vertices;

    for (int i = 0; i < vertices.Length; i++)
    {
        Vector3 offset = Wobble(Time.time + i);
        vertices[i] = vertices[i] + offset;
    }

    // Update the mesh with the new vertex positions
    textMesh.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
}



    // Vector2 Wobble(float time) {
    //     float amplitude = 0.005f; // Adjust this value to change the height of the wave
    //     float frequency = 0.1f; // Adjust this value to change the speed of the wave
    //     return amplitude * new Vector2(Mathf.Sin(time * frequency), Mathf.Cos(time * frequency));
    // }

    Vector2 Wobble(float time) {
        float amplitude = 0.005f; // Adjust this value to change the height of the wave
        float frequency = 0.2f; // Adjust this value to change the speed of the wave
    return amplitude * new Vector2(Mathf.PerlinNoise(time * frequency, 0.0f), Mathf.PerlinNoise(0.0f, time * frequency));
}














    // public TMP_Text textComponent;
    

    // void Update()
    // {
    //     textComponent.ForceMeshUpdate();
    //     var textInfo = textComponent.textInfo;

    //     // can use i to apply diff effects per character
    //     for (int i = 0; i < textInfo.characterCount; ++i) {
    //         var charInfo = textInfo.characterInfo[i];

    //         // skip if char is invisible
    //         if (!charInfo.isVisible) {
    //             continue;
    //         }

    //         var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;


    //         // one loop for each of the 4 vertices of character
    //         for (int j = 0; i < 4; ++j) {
    //             var orig = verts[charInfo.vertexIndex + j];
                
    //             // override this vertex with modified version! HAHA manipulation !!
    //             verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time*2f + orig.x*0.01f) * 10f, 0);
    //         }
    //     }
        
    //     for (int i = 0; i < textInfo.meshInfo.Length; ++i) {
    //         var meshInfo = textInfo.meshInfo[i];
    //         meshInfo.mesh.vertices = meshInfo.vertices;
    //         textComponent.UpdateGeometry(meshInfo.mesh, i); 
    //     }
    // }
}
