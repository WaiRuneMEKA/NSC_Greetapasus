using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnClick : MonoBehaviour
{
    public ParticleSystem particles;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            particles.transform.position = mousePosition;
            particles.Play();
        }
    }
}
