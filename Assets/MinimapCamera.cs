using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code modified from MRsive's CameraFollow.cs
public class MinimapCamera : MonoBehaviour
{
    public GameObject target;
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
        transform.position = new Vector3(target.transform.position.x,
            target.transform.position.y+10, target.transform.position.z);
        transform.rotation = Quaternion.Euler(90f,
            target.transform.eulerAngles.y, 0f);
    }
}
