using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistUI : MonoBehaviour
{
    public Text field;
    int id;
    public Transform target;
    bool isOn;
    CameraInGame cameraInGame;

    public void Init(int id)
    {
        cameraInGame = WorldManager.Instance.cameraInGame;
        this.id = id;
        GetComponent<Button>().onClick.AddListener(delegate () { Clicked(); });
        this.field.text = UIMain.Instance.settings.artworks[id].artist;
        isOn = true;
    }
    void Clicked()
    {
        UIMain.Instance.ButtonClicked(id);
    }
    void Update()
    {
        if (isOn)
            transform.position = cameraInGame.cam.WorldToScreenPoint(target.transform.position);
    }
}
