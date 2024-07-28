using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card> ();
    public List<Card> container = new List<Card> ();
    public static List<Card> staticDeck = new List<Card> ();

    public int x;
    public static int deckSize;
    public static int count;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;
    public GameObject cardInDeck5;
    public GameObject cardInDeck6;
    public GameObject cardInDeck7;
    public GameObject cardInDeck8;
    public GameObject cardInDeck9;
    public GameObject cardInDeck10;

    public GameObject CardToHand;

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
        count = 0;

        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0,8);
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
        if(deckSize<90)
        {
            cardInDeck1.SetActive(false);
        }
        if(deckSize<80)
        {
            cardInDeck2.SetActive(false);
        }
        if(deckSize<70)
        {
            cardInDeck3.SetActive(false);
        }
        if(deckSize<60)
        {
            cardInDeck4.SetActive(false);
        }
        if(deckSize<50)
        {
            cardInDeck5.SetActive(false);
        }
        if(deckSize<40)
        {
            cardInDeck6.SetActive(false);
        }
        if(deckSize<30)
        {
            cardInDeck7.SetActive(false);
        }
        if(deckSize<20)
        {
            cardInDeck8.SetActive(false);
        }
        if(deckSize<2)
        {
            cardInDeck9.SetActive(false);
        }
        if(deckSize<1)
        {
            cardInDeck10.SetActive(false);
        }

        if(TurnSystem.startTurn == true && TurnSystem.isYourTurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;
        }

        if(TurnSystem.startAITurn == true && TurnSystem.isYourTurn == false)
        {
            StartCoroutine(AIDraw(1));
            TurnSystem.startAITurn = false;
        }

        if(ThisCardSteal.drawX > 0)
        {
            StartCoroutine(Draw(ThisCardSteal.drawX));
            ThisCardSteal.drawX = 0;
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
        for(int i=0; i<=4; i++)
        {
            count++;
            yield return new WaitForSeconds(1);
            // GameObject.Find("AICard(Clone)").name = "1" + count;
            Instantiate(CardToHand, transform.position, transform.rotation);
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
            Instantiate(CardToHand, transform.position, transform.rotation);
            
        }
    }


    IEnumerator AIDraw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            count++;
            yield return new WaitForSeconds(1);
            // GameObject.Find("AICard(Clone)").name = "1" + count;
            Instantiate(CardToHand, transform.position, transform.rotation);
            
        }
    }

    
}
