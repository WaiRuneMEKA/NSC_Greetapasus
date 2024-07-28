using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource run;

    void LaughSound()
    {
        run.Play();
    }
}
