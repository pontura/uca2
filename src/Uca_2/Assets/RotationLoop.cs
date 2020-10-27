using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLoop : MonoBehaviour
{
    public float speed = 10;
    private void Start()
    {
        transform.Rotate(Vector3.up * Random.Range(0,360));
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
