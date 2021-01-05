using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullData : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] panels;
    public bool opened;

    public void Start()
    {
        Close();
    }
    private void Reset()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
    }
    public void SetOn(int id)
    {
        opened = true;
        Reset();
        panel.SetActive(true);
        panels[id].SetActive(true);
    }
    public void Close()
    {
        opened = false;
        Reset();
        panel.SetActive(false);
    }
}
