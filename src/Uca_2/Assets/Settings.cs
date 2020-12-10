using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Settings : MonoBehaviour
{
    public ArtworkData[] artworks;
    [Serializable]
    public class ArtworkData
    {
        public string artist;
        public string name;
        public string year;
        public string desc;
    }
}
