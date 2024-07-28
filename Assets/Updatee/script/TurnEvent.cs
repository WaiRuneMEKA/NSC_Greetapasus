using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEvent : MonoBehaviour
{
    private Animator Anime;
    public GameObject Effect;

    private Animator Anime2;
    public GameObject Effect2;

    void Start()
    {
        Effect = GameObject.Find("EFFECT");
        Anime = Effect.GetComponent<Animator>();

        Effect2 = GameObject.Find("background");
        Anime2 = Effect2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestEvent()
    {
        if (TurnSystem.TurnCount == 1)
        {
            Debug.Log("EventOne");


        }

        if (TurnSystem.TurnCount == 2)
        {
            Debug.Log("EventTwo");

            EnemyShield.shield += 1;
            Shield.shield += 1;

            Anime.SetTrigger("ee1");
            //TurnSystem.currentMana -= 1;
            ////TurnSystem.currentEnemyMana -= 1;
            //TurnSystem.currentCoin -= 1;

            //Anime.SetTrigger("trc1");
            ////Anime.SetTrigger("trm1");
            ///
            //Anime.SetTrigger("SCshk");
        }

        if (TurnSystem.TurnCount == 3)
        {
            Debug.Log("EventThree");

            TurnSystem.currentMana -= 1;
            TurnSystem.currentEnemyMana -= 1;

            Anime.SetTrigger("escm1");
        }

        if (TurnSystem.TurnCount == 4)
        {
            Debug.Log("EventFour");

            EnemyHealth.health += 1;
            Health.health += 1;

            Anime.SetTrigger("edc1");
        }

        if (TurnSystem.TurnCount == 5)
        {
            Debug.Log("EventFive");

            TurnSystem.currentMana += 1;
            TurnSystem.currentEnemyMana += 1;
            TurnSystem.currentCoin += 1;

            Anime.SetTrigger("ecm1");
        }
        if (TurnSystem.TurnCount == 6)
        {
            Debug.Log("EventSix");

            EnemyShield.shield -= 1;
            Shield.shield -= 1;

            Anime.SetTrigger("esc1");
        }
    }
}
