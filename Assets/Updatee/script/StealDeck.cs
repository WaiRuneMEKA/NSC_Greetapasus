using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealDeck : MonoBehaviour
{
    private Animator Anime;
    public GameObject Effect;

    public List<Card> deck = new List<Card> ();
    public List<Card> container = new List<Card> ();
    public static List<Card> staticDeck = new List<Card> ();

    public int x;
    public static int deckSize;

    public GameObject FartToHand;

    public GameObject CardBack;
    public GameObject Deck;

    public GameObject[] Clones;

    public GameObject Hand;

    void Start() 
    {
        Effect = GameObject.Find("EFFECT");

        Anime = Effect.GetComponent<Animator>();

        x=0;
        deckSize = 10;

        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(10,11);
            deck[i] = CardDataBase.cardList[x];
        }

        // StartCoroutine(startGame());
    }

    void Update ()
    {
        staticDeck = deck;
        // if(deckSize <= 0)
        // {
        //     LoseTextGameObject.SetActive(true);
        //     LoseText.text = "You Lose";
        // }
        
        // staticDeck = deck;

        // if(TurnSystem.startAITurn == true)
        // {
        //     StartCoroutine(Draw(1));
        //     TurnSystem.startAITurn = false;
        // }

        // if(ThisCardAI.drawX > 0)
        // {
        //     StartCoroutine(Draw(ThisCardAI.drawX));
        //     ThisCardAI.drawX = 0;
        // }



    }


    IEnumerator FartDraw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(FartToHand, transform.position, transform.rotation);
        }
    }

    public void FartX()
    {
        if(TurnSystem.currentMana > 0 && TurnSystem.currentCoin > 0)
        {
            TurnSystem.currentMana -= 1;
            TurnSystem.currentCoin -= 1;
            Anime.SetTrigger("trd2");
            StartCoroutine(FartDraw(1));
        }   
    }

    
}
