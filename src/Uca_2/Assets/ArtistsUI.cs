using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtistsUI : MonoBehaviour
{
    public ArtistUI[] all;
    public GameObject panel;

    void Start()
    {
        int id = 0;
        foreach(ArtistUI i in  all)
        {
            i.Init(id);
            id++;
        }           
    }
    public void SetState(bool on)
    {
        foreach (ArtistUI i in all)
            i.gameObject.SetActive(on);
    }
}
