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

    public void GotoDesc()
    {
        GetComponent<Animation>().Play("gotoDesc");
    }
    public void GotoBall()
    {
        GetComponent<Animation>().Play("camBack");
    }
    public void SetDestination(Vector3 _dest)
    {
        dest = _dest;
        dest.y = 0;
    }
    private void Update()
    {
        if (dest == Vector3.zero)
            return;
        if (Vector3.Distance(transform.position, dest) < .1f)
            return;

        Vector3 pos = target.transform.position;
        target.transform.position = Vector3.Lerp(pos, dest, targetSpeed * Time.deltaTime);
        pivot.transform.LookAt(target.transform);
        transform.position = Vector3.Lerp(transform.position, pos, camSpeed * Time.deltaTime);
    }
}
