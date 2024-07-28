using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimatio : MonoBehaviour
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


