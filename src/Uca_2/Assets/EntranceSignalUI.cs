using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntranceSignalUI : MonoBehaviour
{
    Transform container;
    public GameObject panel;
    public CameraInGame cameraInGame;
    public Text field;

    void Start()
    {
        Events.OnEntranceSignal += OnEntranceSignal;
        OnEntranceSignal(null);
    }
    void OnDestroy()
    {
        Events.OnEntranceSignal -= OnEntranceSignal;
    }
    void OnEntranceSignal(Transform container)
    {
        if (container == null)
            panel.SetActive(false);
        else
        {
            panel.SetActive(true);            
        }
        this.container = container;
    }
    void Update()
    {
        if (container == null)
            return;
        panel.transform.position = cameraInGame.cam.WorldToScreenPoint(container.transform.position);
    }
    public void OnClicked()
    {
        print("Click " + cameraInGame.state);

        if (cameraInGame.state == CameraInGame.states.OUTSIDE)
        {
            Events.OnEnterEntranceSignal(true);
            field.text = "SALIR";
        }            
        else
        {
            Events.OnEnterEntranceSignal(false);
            field.text = "ENTRAR";
        }        
    }
    public void Reset()
    {
        if(cameraInGame.state == CameraInGame.states.INSIDE)
        {
            OnClicked();
        }
    }
}
