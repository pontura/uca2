using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CameraInGame cam;
    bool rotating;
    Vector2 initialPos;
    Vector2 initialRot;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rotating = true;
            initialPos = Input.mousePosition;
            initialRot = cam.transform.localEulerAngles;
        }
        if (Input.GetMouseButtonUp(0))
        {
            rotating = false;
            initialPos = Vector2.zero;
        }
        if (rotating && initialPos != Vector2.zero)
        {
            float _x = initialPos.x - Input.mousePosition.x;
            float _rot_y = initialRot.y + _x;
            cam.transform.localEulerAngles = (new Vector3(0, _rot_y, 0));
        }
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
