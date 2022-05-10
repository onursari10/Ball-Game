using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Ball;
    public Vector3 takip;

   
    void Start()
    {
       
    }

    
    void FixedUpdate()
    {
        transform.position = Ball.transform.position + takip;
    }
}
