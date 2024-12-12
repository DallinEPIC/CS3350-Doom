using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBehaviour : MonoBehaviour
{
    void Update()
    {
        Vector3 v = PlayerBehaviour.instance.transform.position;
        transform.LookAt(new Vector3(v.x, transform.position.y, v.z));
        transform.Rotate(0, 180, 0);
    }
}
