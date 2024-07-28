using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouses : MonoBehaviour
{
    public Animation animation;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animation.Play();
        }
    }
}
