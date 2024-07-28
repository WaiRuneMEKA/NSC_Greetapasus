using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int y;
    public static int deckSize;

    public GameObject CardToHand;

    public GameObject CardBack;
    public GameObject Deck;

    public GameObject[] Clones;

    public GameObject Hand;

    public Text LoseText;
    public GameObject LoseTextGameObject;

    void Start()
    {
        y = 0;
        deckSize = 100;

        for (int i = 0; i < deckSize; i++)
        {
            y = Random.Range(9, 11);
            deck[i] = CardDataBase.cardList[y];
        }
    }

    void Update()
    {
        if (deckSize <= 0)
        {
            LoseTextGameObject.SetActive(true);
            LoseText.text = "You Lose";
        }

        staticDeck = deck;

        if (ThisCardSpe.CraftX > 0)
        {
            StartCoroutine(DrawCraft(ThisCardSpe.CraftX));
            ThisCardSpe.CraftX = 0;
        }



    }


    IEnumerator DrawCraft(int y)
    {
        for (int i = 0; i < y; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

            IEnumerator CraftBeta()
    {
        Destroy(GameObject.Find("CardToHand(Clone)"));
        yield return new WaitForSeconds(1);
        Destroy(GameObject.Find("CardToHand(Clone)"));
        yield return new WaitForSeconds(1);
        ThisCardSpe.CraftX = 1;

    }
    public void CraftBeta2()
    {
        StartCoroutine(CraftBeta());
    }
}
