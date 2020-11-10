using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public CameraInGame cameraInGame;
    public ArtPiece[] all;

    public void Awake()
    {
        Instance = this;
        // debugField.text = SystemInfo.graphicsDeviceType.ToString();
    }
    public void Goto(int id)
    {
        cameraInGame.SetDestination(all[id].transform.position);
    }
}
