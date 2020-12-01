using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var charPos = Renderer.transform.position;  
        transform.position = new Vector3(charPos.x,charPos.y, transform.position.z);
    }
}
