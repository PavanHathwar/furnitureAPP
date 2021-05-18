using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public GameObject objectToPlace;
    public GameObject selectCube;
    public GameObject shadow;
    private GameObject generatedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void PlaceObject(Pose placementPose)
    {
        selectCube.transform.parent = objectToPlace.transform;
        shadow.transform.parent = objectToPlace.transform;
        selectCube.transform.localScale += objectToPlace.GetComponent <BoxCollider>().size;
        selectCube.transform.localPosition += objectToPlace.GetComponent <BoxCollider>().center;
        shadow.transform.localScale += objectToPlace.GetComponent <BoxCollider>().size;
        shadow.transform.localPosition += objectToPlace.GetComponent <BoxCollider>().center;
        generatedObject=Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        generatedObject.transform.Find("selectCube").gameObject.SetActive(false);
        generatedObject.transform.Find("shadow").gameObject.SetActive(false);

    }

    public GameObject GetGeneratedObject()
    {
        return generatedObject;
    }

}