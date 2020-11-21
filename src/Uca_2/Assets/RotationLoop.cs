using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLoop : MonoBehaviour
{
    public float speed_y = 10;
    public float speed_x = 10;
    public float speed_z = 10;
    public bool random;
    public float randomTime;

    private void Start()
    {
      //  transform.Rotate(Vector3.up * Random.Range(0,360));
    }
    float timer;
    void Update()
    {
        float _x = speed_x;
        float _y = speed_y;
        float _z = speed_z;
        timer += Time.deltaTime;
        if (timer> randomTime && random)
        {
            _x = speed_x * Random.Range(-100, 100);
            _y = speed_y * Random.Range(-100, 100);
            _z = speed_z * Random.Range(-100, 100);
            timer = 0;
        }
        transform.Rotate(new Vector3(Time.deltaTime * _x, Time.deltaTime * _y, Time.deltaTime * _z));
    }
}
