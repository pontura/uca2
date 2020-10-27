using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class UIMain : MonoBehaviour
{

    public Text debugField;
    public static UIMain Instance;
    public CameraInGame cameraInGame;
    public GameObject camTarget;

    public void Awake()
    {
        Instance = this;
       // debugField.text = SystemInfo.graphicsDeviceType.ToString();
    }
}
