using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLoop : MonoBehaviour
{
    public SkinnedMeshRenderer smr;
    public float value = 1;
    public int num = 0;
    public float speed = 10;

    private void Start()
    {
      //  transform.Rotate(Vector3.up * Random.Range(0,360));
    }
    void Update()
    {
        smr.SetBlendShapeWeight(num,  value);
      //  transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
