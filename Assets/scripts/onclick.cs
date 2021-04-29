using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick : MonoBehaviour
{
    [SerializeField] private LayerMask ClickablesLayer;
    [SerializeField]private Camera arCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            RaycastHit rayhit;
            if (Physics.Raycast(arCamera.ScreenPointToRay))
        }
    }
}
