using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;

    private void Start()
    {
        
    }

    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.up * speed);   
    }
}
