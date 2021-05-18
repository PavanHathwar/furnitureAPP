using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ColourCustomizer : MonoBehaviour
{
    
    public void CustomizeColor(Material material)
    {
        GameObject targetGameObject = Controller.instance.GetGeneratedObject();

        targetGameObject.GetComponent<MeshRenderer>().material = material;
    }
}
