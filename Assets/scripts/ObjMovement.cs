using UnityEngine;
using UnityEngine.UI;

public class ObjMovement : MonoBehaviour
{
    
    private Touch touch;
   
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject ColourControlPanel;
    [SerializeField] private LayerMask interactableLayers;

    private float speedModifier;
    private float initialDistance;
    private Vector3 initialScale;
    private GameObject selectedObject=null;
    private Button leftButton;
    private Button rightButton;
    
// Start is called before the first frame update

    void Start()
    {
        speedModifier = 0.002f;
        leftButton=controlPanel.transform.Find("left").GetComponent<Button>(); 
        rightButton=controlPanel.transform.Find("right").GetComponent<Button>();
        leftButton.onClick.AddListener(LeftRotate);
        rightButton.onClick.AddListener(RightRotate);

    }

    private void RightRotate()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(new Vector3(0,-10,0));
        }
    }

    private void LeftRotate()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(new Vector3(0,10,0));
        }
    }

    // Update is called once per frame

    void Update()
    {

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10, interactableLayers))
            {
                GameObject newSelectedObject = hit.transform.gameObject;

                Move(touch,newSelectedObject);
            }
        }

        if (Input.touchCount == 2)
        { 
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, interactableLayers))
            {
                GameObject newSelectedObject = hit.transform.gameObject;

                Selecting(touch, newSelectedObject);
            }
        }
    }

    void Move(Touch touch,GameObject newselectedObject)
    { //Material material = newselectedObject.GetComponent<MeshRenderer>().material;
        if (touch.phase == TouchPhase.Moved && selectedObject != null)
        {
            newselectedObject.transform.position = new Vector3(

                newselectedObject.transform.position.x + touch.deltaPosition.x * speedModifier,
                newselectedObject.transform.position.y,

                newselectedObject.transform.position.z + touch.deltaPosition.y * speedModifier);
            
        }
    }

    void Selecting(Touch touch, GameObject newSelectedObject)
    {
        if (touch.phase == TouchPhase.Began)
        {
            if (selectedObject == null)
            {
                selectedObject = newSelectedObject;
                selectedObject.transform.position = new Vector3(

                    selectedObject.transform.position.x,
                    (selectedObject.transform.position.y)+1,

                    selectedObject.transform.position.z);

                controlPanel.SetActive(true);
                ColourControlPanel.SetActive(false);
                selectedObject.transform.Find("selectCube").gameObject.SetActive(true);
                selectedObject.transform.Find("shadow").gameObject.SetActive(true);
                GameObject shadow = selectedObject.transform.Find("shadow").gameObject;
                shadow.transform.position=new Vector3(

                    selectedObject.transform.position.x,
                    (selectedObject.transform.position.y)-(1),

                    selectedObject.transform.position.z);

            }
            else if (selectedObject)
            {
                selectedObject.transform.position = new Vector3(

                    selectedObject.transform.position.x,
                    (selectedObject.transform.position.y)-1,

                    selectedObject.transform.position.z);
                       
                
                controlPanel.SetActive(false);
                ColourControlPanel.SetActive(true);
                selectedObject.transform.Find("selectCube").gameObject.SetActive(false);
                selectedObject.transform.Find("shadow").gameObject.SetActive(false);
                selectedObject = null;
            }
        }
    }
}

 
 