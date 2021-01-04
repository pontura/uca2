using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class UIMain : MonoBehaviour
{
    public GameObject artButtons;
    public Text debugField;
    public static UIMain Instance;
    public CameraInGame cameraInGame;
    public GameObject camTarget;
    public WorldManager worldManager;
    public Button[] buttons;
    public Settings settings;
    public ArtistsUI artistsUI;
    public ArtipieceData artipieceData;
    int lastButtonOn;

    public void Awake()
    {
        Instance = this;
        // debugField.text = SystemInfo.graphicsDeviceType.ToString();
       
    }
    private void Start()
    {
        ButtonClicked(4);
    }
    public void ButtonClicked(int id)
    {
        
        this.lastButtonOn = id;
        if (id == 4)
        {
            timer = 0;
            artistsUI.SetState(true);
        }            
        else
            artistsUI.SetState(false);
        GetComponent<EntranceSignalUI>().Reset();
        worldManager.Goto(id);

        foreach(Button b in buttons)
            b.interactable = true;

        buttons[id].interactable = false;
        artipieceData.SetOn(id);
    }
    bool pressed;
    float timer;
    float lastTimeMouseMove;
    Vector3 mousePos;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            pressed = true;
        }            
        else
            pressed = false;

        if (mousePos == Input.mousePosition)
        {
            if(!pressed)
                timer += Time.deltaTime;            
            if (timer > 2)
                SetUIPanels(false);
        } else
        {
            mousePos = Input.mousePosition;
            timer = 0;
            SetUIPanels(true);
        }            
    }
    void SetUIPanels(bool isOn)
    {       
        timer = 0;
        artButtons.SetActive(isOn);
        artistsUI.panel.SetActive(isOn);

        if (lastButtonOn != 4)
            artipieceData.panel.SetActive(isOn);
    }
}
