using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CameraInGame cam;
    bool rotating;
    Vector2 initialPos;
    Vector2 initialRot;
    Vector2 pivotInitialRot;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rotating = true;
            initialPos = Input.mousePosition;
            initialRot = cam.transform.localEulerAngles;
            pivotInitialRot = cam.pivot.transform.localEulerAngles;
        }
        if (Input.GetMouseButtonUp(0))
        {
            rotating = false;
            initialPos = Vector2.zero;
        }
        if (rotating && initialPos != Vector2.zero)
        {
            float _x = (initialPos.x - Input.mousePosition.x)/ 3;
            float _rot_y = initialRot.y + _x;

            float _y = initialPos.y - Input.mousePosition.y;
            float _rot_x = (_y/4);
            //if (_rot_x < 0)
            //    _rot_x = 0;
            //else if (_rot_x > 30)
            //    _rot_x = 30;
            cam.SetMouseRotation(_rot_y, _rot_x);
        }
        else if(!cam.travelling)
            cam.beingRotate = false;
        return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {

                }
            }
        }
    }
}
