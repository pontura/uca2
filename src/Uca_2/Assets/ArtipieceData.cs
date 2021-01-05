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
    FullData fullData;

    int id;

    public void Start()
    {
        fullData = GetComponent<FullData>();
        SetOn(4);
    }
    
    public void SetOn(int id)
    {
        fullData = GetComponent<FullData>();
        this.id = id;
        if (id == 4)
        {
            panel.SetActive(false);
            fullData.Close();
            return;
        }
        panel.SetActive(true);
        Settings settings = GetComponent<Settings>();
        field1.text = settings.artworks[id].name;
        field2.text = settings.artworks[id].artist;
        field3.text = settings.artworks[id].year;
        if (fullData.opened)
            OpenFull();
    }
    public void OpenFull()
    {
        fullData.SetOn(id);
    }
}
