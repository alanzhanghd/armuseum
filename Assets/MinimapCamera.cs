using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Camera arCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(arCamera.transform.position.x,
            arCamera.transform.position.y, arCamera.transform.position.z);
        transform.rotation = Quaternion.Euler(90f,
            arCamera.transform.eulerAngles.y, 0f);
    }
}
