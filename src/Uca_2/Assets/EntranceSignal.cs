using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSignal : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            SetOn(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            SetOn(false);
        }
    }
    public void SetOn(bool isOn)
    {
        if(isOn)
            Events.OnEntranceSignal(target);
        else
            Events.OnEntranceSignal(null);
    }

}
