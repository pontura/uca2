using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSignalUI : MonoBehaviour
{
    Transform container;
    public GameObject panel;
    public Camera cam;

    void Start()
    {
        Events.OnEntranceSignal += OnEntranceSignal;
        panel.SetActive(false);
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
            panel.SetActive(true);
        this.container = container;
    }
    void Update()
    {
        if (container == null)
            return;
        panel.transform.position = cam.WorldToScreenPoint(container.transform.position);
    }
    public void OnClicked()
    {
        Events.OnEnterEntranceSignal();
    }
}
