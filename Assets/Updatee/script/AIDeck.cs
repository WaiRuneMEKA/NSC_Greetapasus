using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card> ();
    public List<Card> container = new List<Card> ();
    public static List<Card> staticDeck = new List<Card> ();

    public int x;
    public static int deckSize;

    public GameObject AIHand;

    public GameObject CardBack;
    public GameObject Deck;

    public GameObject[] Clones;

    public GameObject Hand;

    public Text LoseText;
    public GameObject LoseTextGameObject;

    void Start() 
    {
        x=0;
        deckSize = 100;

        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0,4);
            deck[i] = CardDataBase.cardList[x];
        }

        StartCoroutine(startGame());
    }

    void Update ()
    {
        if(deckSize <= 0)
        {
            LoseTextGameObject.SetActive(true);
            LoseText.text = "You Lose";
        }
        
        staticDeck = deck;

        if(TurnSystem.startAITurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startAITurn = false;
        }

        if(ThisCardAI.drawX > 0)
        {
            StartCoroutine(Draw(ThisCardAI.drawX));
            ThisCardAI.drawX = 0;
        }



    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
            
        }
    }

    IEnumerator startGame()
    {
        for(int i=0; i<=9; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(AIHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example());
    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(AIHand, transform.position, transform.rotation);
        }
    }

    
}
