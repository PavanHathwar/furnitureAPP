using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    public GameObject placementIndicator;
    private Touch touch;
    [SerializeField] private Material select;
    [SerializeField] private Material deselect;

    private float speedModifier;
    private float initialDistance;
    private Vector3 initialScale;
    
// Start is called before the first frame update

    void Start()
    {
        speedModifier = 0.002f;

    }

// Update is called once per frame

    void Update()
    {

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.transform.gameObject;
                Material material = selectedObject.GetComponent<MeshRenderer>().sharedMaterial;
                
                if (touch.phase == TouchPhase.Moved && material == select)
                {
                    selectedObject.transform.position = new Vector3(

                        selectedObject.transform.position.x + touch.deltaPosition.x * speedModifier,
                        selectedObject.transform.position.y,

                        selectedObject.transform.position.z + touch.deltaPosition.y * speedModifier);
                }
                
            }
        }

        if (Input.touchCount == 2)
        { 
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.transform.gameObject;
                Material material = selectedObject.GetComponent<MeshRenderer>().sharedMaterial;
                if (touch.phase == TouchPhase.Began)
                {
                    if (material == deselect)
                    { 
                        selectedObject.GetComponent<MeshRenderer>().material = select;
                        selectedObject.transform.position = new Vector3(

                            selectedObject.transform.position.x,
                            (selectedObject.transform.position.y)+1,

                            selectedObject.transform.position.z);
                        
                        
                    }

                    if (material == select)
                    {
                        selectedObject.GetComponent<MeshRenderer>().material = deselect;
                        selectedObject.transform.position = new Vector3(

                            selectedObject.transform.position.x,
                            (selectedObject.transform.position.y)-1,

                            selectedObject.transform.position.z);

                    }
                }
            }

            
        }


    }
}

 
 