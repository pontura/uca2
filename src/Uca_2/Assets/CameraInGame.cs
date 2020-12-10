using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInGame : MonoBehaviour
{
    public states state;
    public enum states
    {
        OUTSIDE,
        INSIDE
    }
    public bool transitionZoom;

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
    public Vector3  targetOffset;
    public Animation anim;
    public Vector3 pivotOffset;
    public float pivot_y_filter = 200;
    Vector3 camCenterOrientation;

    private void Start()
    {
        Events.OnEnterEntranceSignal += OnEnterEntranceSignal;
    }
    private void OnDestroy()
    {
        Events.OnEnterEntranceSignal -= OnEnterEntranceSignal;
    }
    private void OnEnterEntranceSignal(bool enter)
    {
        ArtPiece artpiece = WorldManager.Instance.active;
        artpiece.OnZoom(enter);
        transform.eulerAngles = artpiece.camCenterOrientation;
        pivot.transform.localEulerAngles = Vector3.zero;
        transitionZoom = true;

        if (enter)
        {            
            pivotOffset = artpiece.pivotZoomOffset;
            pivot_y_filter = artpiece.pivotZoom_y_filter;
           // dest = artpiece.pivotZoom.transform.position;

           // beingRotate = false;
           // travelling = true;
            state = states.INSIDE;                  
          
        }
        else
        {
            state = states.OUTSIDE;
           // dest = artpiece.pivot.transform.position;
            pivotOffset = artpiece.pivotOffset;
            pivot_y_filter = artpiece.pivot_y_filter;
           // beingRotate = false;
            YSpeed = YInitialSpeed;
        }
    }
    public void SetDestination(ArtPiece artpiece)
    {        
        dest = artpiece.pivot.transform.position;
        pivotOffset = artpiece.pivotOffset;
        pivot_y_filter = artpiece.pivot_y_filter;
        beingRotate = false;
        YSpeed = YInitialSpeed;               
    }
    private void FixedUpdate()
    {
        //if (dest == Vector3.zero)
        //    return;

        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0, targetOffset.y, pivotOffset.z), 0.1f);
                  

        Vector3 pos = target.transform.position;     
        
        target.transform.position = Vector3.Lerp(pos, dest, targetSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, dest) < .01f)
        {
            travelling = false;
            return;
        }

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
        }

        transform.position = Vector3.Lerp(transform.position, pos , camSpeed * Time.deltaTime);
    }
    public void SetMouseRotation(float rot_y,float rot_x)
    {
        //if (transitionZoom)
        //    return;
        beingRotate = true;
        transform.localEulerAngles = (new Vector3(0, rot_y, 0));

       // Vector3 newPivotRot = pivot.transform.eulerAngles;

        targetOffset.y = rot_x/ pivot_y_filter;
        //if (rot_x < 0)
        //    rot_x = 0;
        //else
        //    newPivotRot.x = rot_x;
       // pivot.transform.eulerAngles = Vector3.Lerp(pivot.transform.eulerAngles, newPivotRot, 0.01f);
    }
    public void Animate(string animName)
    {
        anim.Play(animName);
    }
}
