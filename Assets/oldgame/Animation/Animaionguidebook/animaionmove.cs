using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class animaionmove : MonoBehaviour
{
    public PlayableDirector move1;
    // Start is called before the first frame update
    void Start()
    {
        move1 = GetComponent<PlayableDirector>(); 
    }

    
    
    public void aion()
    {
      move1.Play();  
    }
}
