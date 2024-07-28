using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public List<Card> deck = new List<Card> ();
    public List<Card> container = new List<Card> ();
    public static List<Card> staticEnemyDeck = new List<Card> ();

    public List<Card> cardsInHand = new List<Card>();

    public int x;
    public static int deckSize;

    // public GameObject cardInDeck1;
    // public GameObject cardInDeck2;
    // public GameObject cardInDeck3;
    // public GameObject cardInDeck4;
    // public GameObject cardInDeck5;
    // public GameObject cardInDeck6;
    // public GameObject cardInDeck7;
    // public GameObject cardInDeck8;
    // public GameObject cardInDeck9;
    // public GameObject cardInDeck10;

    public GameObject Hand;
    public GameObject Zone;
    public GameObject Graveyard;

    public GameObject CardToHand;

    public GameObject[] Clones;

    public GameObject CardBack;

    public static bool draw;

    public int currentMana;

    public bool[] AiCanSummon;

    public bool drawPhase;
    public bool summonPhase;
    public bool attackPhase;
    public bool endPhase;

    public int[] cardsID;
    
    public int summonThisId;

    public AICardToHand aiCardToHand;

    public int summonID;

    public int howManyCards;

    public bool summoned;

    void Start()
    {
        StartCoroutine(WaitFiveSeconds());

        StartCoroutine(startGame());

        Hand = GameObject.Find("EnemyHand");
        Zone = GameObject.Find("EnemyZone");
        Graveyard = GameObject.Find("My Graveyard");

        x = 0;
        deckSize= 100;

        draw = true;

        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0,5);
            deck[i] = CardDataBase.cardList[x];
        }
    }

    void Update()
    {
        staticEnemyDeck = deck;

        // if(ThisCard.drawX > 0)
        // {
        //     StartCoroutine(EnemyDraw(ThisCard.drawX));
        //     ThisCard.drawX = 0;
        // }

        if(TurnSystem.startTurn == false && draw == false)
        {
            StartCoroutine(EnemyDraw(1));
            draw = true;
        }

        currentMana = TurnSystem.currentEnemyMana;

        if(0 == 0)
        {
            int j = 0;
            howManyCards = 0;
            foreach(Transform child in Hand.transform)
            {
                howManyCards++;
            }
            foreach(Transform child in Hand.transform)
            {
                cardsInHand[j] = child.GetComponent<AICardToHand>().thisCard[0];
            }

            for(int i=0;i<100;i++)
            {
                if(i >= howManyCards)
                {
                    cardsInHand[i] = CardDataBase.cardList[0];
                }
            }
            j=0;
        }

        if(TurnSystem.isYourTurn == false)
        {
            for(int i=0;i<100;i++)
            {
                if(cardsInHand[i].id != 0)
                {
                    if(currentMana >= cardsInHand[i].cost)
                    {
                        AiCanSummon[i] = true;
                    }
                }
            }
        }
        else
        {
            for (int i=0;i<100;i++)
            {
                AiCanSummon[i] = false;
            }
        }

        if(TurnSystem.isYourTurn == false)
        {
            drawPhase = true;
        }

        if(drawPhase == true && summonPhase == false && attackPhase == false)
        {
            StartCoroutine(WaitForSummonPhase());
        }

        if(TurnSystem.isYourTurn == true)
        {
            drawPhase = false;
            summonPhase = false;
            attackPhase = false;
            endPhase = false;
        }









        if(summonPhase == true)
        {
            summonID = 0;
            summonThisId = 0;

            int index = 0;
            for(int i=0;i<100;i++)
            {
                if(AiCanSummon[i] == true)
                {
                    cardsID[index] = cardsInHand[i].id;
                    index++;
                }
            }

            for(int i=0;i<100;i++)
            {
                if(cardsID[i] != 0)
                {
                    if(cardsID[i] > summonID)
                    {
                        summonID = cardsID[i];
                    }
                }
            }

            summonThisId = summonID;

            foreach(Transform child in Hand.transform)
            {
                if(child.GetComponent<AICardToHand>().id == summonThisId && CardDataBase.cardList[summonThisId].cost <= currentMana)
                {
                    child.transform.SetParent(Zone.transform);
                    TurnSystem.currentEnemyMana -= CardDataBase.cardList[summonThisId].cost;
                    // Summon();
                    break;
                }
            }

            summonPhase = false;
            attackPhase = true;
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
        StartCoroutine(ShuffleNow());
    }

    IEnumerator startGame()
    {
        for(int i=0; i<=4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
            
        }
    }

    IEnumerator EnemyDraw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(5);
    }

    IEnumerator WaitForSummonPhase()
    {
        yield return new WaitForSeconds(5);
        summonPhase = true;
    }

    // public void Summon()
    // {
    //     if( addXmaxMana > 0)
    //     {
    //         MaxMana(addXmaxMana);
    //         Destroy();
    //     }
    //     if( drawXcards > 0)
    //     {
    //         drawX = drawXcards;
    //         Destroy();
    //     }
    //     if ( healXpower > 0)
    //     {
    //         Heal();
    //         Destroy();   
    //     }
    // }
}
