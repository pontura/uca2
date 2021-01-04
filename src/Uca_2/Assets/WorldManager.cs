using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public CameraInGame cameraInGame;
    public ArtPiece[] all;
    public ArtPiece active;

    public void Awake()
    {
        Instance = this;
    }

    public void Goto(int id)
    {
        if(active != null)
            active.SetState(false);
        active = all[id];
        cameraInGame.SetDestination(active);
        active.SetState(true);
    }
}
