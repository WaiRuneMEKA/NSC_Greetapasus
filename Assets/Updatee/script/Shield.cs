using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public static int shield;
    public static int numOfshields;

    public Image[] shields;
    public Sprite fullshieldies;
    public Sprite emptyshieldies;

    void Start()
    {
        shield = 1;
        numOfshields = 2;
    }

    void Update()
    {
        if (shield > numOfshields)
        {
            shield = numOfshields;
        }

        for (int i = 0; i < shields.Length; i++)
        {
            if (i < shield)
            {
                shields[i].sprite = fullshieldies;
            }
            else
            {
                shields[i].sprite = emptyshieldies;
            }

            if (i < numOfshields)
            {
                shields[i].enabled = true;
            }
            else
            {
                shields[i].enabled = false;
            }
        }
    }
}
