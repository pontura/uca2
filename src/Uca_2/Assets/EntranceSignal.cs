using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSignal : MonoBehaviour
{
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
        print("ENTRA");
        if(isOn)
            Events.OnEntranceSignal(transform);
        else
            Events.OnEntranceSignal(null);
    }

}
