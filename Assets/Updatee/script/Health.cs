using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int health;
    public static int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    //public int Shield;
    //public static int Shield;
    //public static int numOfShield;

    //public Image[] Shield;
    //public Sprite fullShield;
    //public Sprite emptyShield;

    void Start()
    {
        health = 2;
        numOfHearts = 2;

        //Shield = 2;
        //numOfShield = 2;
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
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            } 
            else 
            {
                hearts[i].enabled = false;
            }
        }

        //if (Shield > numOfShield)
        //{
        //    Shield = numOfShield;
        //}

        //for (int i = 0; i < Shield.Length; i++)
        //{
        //    if (i < Shield)
        //    {
        //        Shield[i].sprite = fullShield;
        //    }
        //    else
        //    {
        //        Shield[i].sprite = emptyShield;
        //    }

        //    if (i < numOfShield)
        //    {
        //        Shield[i].enabled = true;
        //    }
        //    else
        //    {
        //        Shield[i].enabled = false;
        //    }
        //}
    }




}
