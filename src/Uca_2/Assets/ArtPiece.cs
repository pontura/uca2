using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject pivotZoom;
    public EntranceSignal entranceSignal;
    public Transform pivot;
    public Vector3 pivotOffset;
    public Vector3 pivotZoomOffset;
    public float pivot_y_filter;
    public float pivotZoom_y_filter;
    public Vector3 camCenterOrientation;
    public GameObject activateOnlyOnZoom;
    public GameObject activateOnSelect;

    private void Start()
    {
        OnZoom(false);
        gameObject.SetActive(false);
        Invoke("Init", 1);
    }
    void Init()
    {
        gameObject.SetActive(true);
    }
    public void OnZoom(bool isOn)
    {
        if (activateOnlyOnZoom != null)
            activateOnlyOnZoom.SetActive(isOn);            
    }
    public void SetState(bool isOn)
    {
        if(activateOnSelect != null)
            activateOnSelect.SetActive(isOn);
    }

}
