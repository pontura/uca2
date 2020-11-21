using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInGame : MonoBehaviour
{
    public Camera cam;
    public GameObject target;
    public GameObject pivot;
    Vector3 dest;
    public float targetSpeed = 2;
    public float camSpeed = 1;
    public float YInitialSpeed = 1;
    public float YAcceleration = 1;
    public float YSpeed;
    public bool beingRotate;
    public bool travelling;
    public float initialOffset = -1.25f;

    private void Start()
    {
        Events.OnEnterEntranceSignal += OnEnterEntranceSignal;
    }
    private void OnDestroy()
    {
        Events.OnEnterEntranceSignal -= OnEnterEntranceSignal;
    }
    private void OnEnterEntranceSignal()
    {
        initialOffset = 0;
    }
    public void SetDestination(Vector3 _dest)
    {
        beingRotate = false;
        travelling = true;
        YSpeed = YInitialSpeed;
        dest = _dest;
        dest.y = 0;
    }
    private void FixedUpdate()
    {
        if (dest == Vector3.zero)
            return;
        if (Vector3.Distance(transform.position, dest) < .1f)
        {
            travelling = false;
            return;
        }            

        Vector3 pos = target.transform.position;     
        
        target.transform.position = Vector3.Lerp(pos, dest, targetSpeed * Time.deltaTime);

        if (YSpeed > 0)
            YSpeed -= YAcceleration * Time.deltaTime;
        else
            YSpeed = 0;

        
        pivot.transform.localPosition = Vector3.Lerp(pivot.transform.localPosition, new Vector3(0, YSpeed, 0), 0.1f);

        if (!beingRotate)
        {

            Vector3 relativePos = target.transform.position - pivot.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            pivot.transform.rotation = Quaternion.Lerp(pivot.transform.rotation, toRotation, 1 * Time.deltaTime);


           // pivot.transform.LookAt(target.transform);
        }

        transform.position = Vector3.Lerp(transform.position, pos, camSpeed * Time.deltaTime);
    }
    public void SetMouseRotation(float rot_y,float rot_x)
    {
        beingRotate = true;
        transform.localEulerAngles = (new Vector3(0, rot_y, 0));

        Vector3 newPivotRot = pivot.transform.eulerAngles;
        newPivotRot.x = rot_x;
        pivot.transform.eulerAngles = Vector3.Lerp(pivot.transform.eulerAngles, newPivotRot, 0.01f);
    }
}
