using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomizer : MonoBehaviour
{
    public float totalRandomTime;

    Animation anim;
    void OnEnable()
    {
        anim = GetComponent<Animation>();
        Ranomize();
    }

    void Ranomize()
    {
        if (!anim.isPlaying)
            Invoke("Ranomize", 0.1f);
        else
        {
            anim[anim.clip.name].normalizedTime = (float)(Random.Range(0, 100))/100;

        }
    }
}
