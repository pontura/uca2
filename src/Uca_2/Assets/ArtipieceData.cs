using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtipieceData : MonoBehaviour
{
    public GameObject panel;
    public Text field1;
    public Text field2;
    public Text field3;
    public Text field4;

    public void Start()
    {
        SetOn(4);
    }

    public void SetOn(int id)
    {
        if (id == 4)
        {
            panel.SetActive(false);
            return;
        }
        panel.SetActive(true);
        Settings settings = GetComponent<Settings>();
        field1.text = settings.artworks[id].name;
        field2.text = settings.artworks[id].artist;
        field3.text = settings.artworks[id].year;
        field4.text = settings.artworks[id].desc;
    }
}
