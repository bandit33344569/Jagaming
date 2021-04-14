using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    int distance = -5;
    float lift = 1.5f;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, lift, distance) + target.position;
        transform.LookAt(target);
    }
}
