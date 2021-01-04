using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smooth;
    Vector3 dest;

    void Update()
    {
        Vector3 targetPos = target.transform.position;
        targetPos += offset;
        dest = Vector3.Lerp(dest, targetPos, smooth);
        transform.LookAt(dest);
    }
}
