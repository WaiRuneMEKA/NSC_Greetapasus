using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heaithtext : MonoBehaviour
{
    public static int health;
    public static int numOfHearts;

    public Image[] hearts;
    public int fullHeartValue = 1;
    public int emptyHeartValue = 0;

    void Start()
    {
        health = 2;
        numOfHearts = 2;
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
                hearts[i].GetComponentInChildren<Text>().text = fullHeartValue.ToString();
            }
            else
            {
                hearts[i].enabled = false;
                hearts[i].GetComponentInChildren<Text>().text = emptyHeartValue.ToString();
            }
        }
    }
}
