//Code controlling the top view map
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    private void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, Target.position.z);
        transform.rotation = Quaternion.Euler(90f, Target.eulerAngles.y, 0f);
    }
}
