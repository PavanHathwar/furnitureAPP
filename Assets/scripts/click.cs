using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    [SerializeField]
    private Material select;

    [SerializeField]
    private Material deselect;

    private MeshRenderer rend;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void selected()
    {
        rend.material = select;
    }

    void deselected()
    {
        rend.material = deselect;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
