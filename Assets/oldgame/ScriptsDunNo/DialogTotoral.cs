using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTotoral : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++) //ถ้ากด1 1มา
        {
            if(i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else 
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            spawner.SetActive(true);
        }
    }
}
