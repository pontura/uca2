using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static System.Action<Transform> OnEntranceSignal = delegate { };
    public static System.Action<bool> OnEnterEntranceSignal = delegate { };
}
