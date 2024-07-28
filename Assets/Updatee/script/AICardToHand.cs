using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICardToHand : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();

    public static List<Card> cardsInHandStatic = new List<Card>();
    public List<Card> cardsInHand = new List<Card>();
    public static int cardsInHandNumber;

    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Text nameText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;

    public int hurted;
    public int actualpower;
    public int returnXcards;

    public int healXpower;

    public GameObject Hand;

    public int z = 0;
    public GameObject It;

    public int numberOfCardsInDeck;

    public bool isTarget;
    public GameObject Graveyard;

    public bool thisCardCanBeDestroyed;

    public GameObject cardBack;
    public GameObject AiZone;

    

    void Start()
    {

        thisCard[0] = CardDataBase.cardList[thisId];
        Hand = GameObject.Find("EnemyHand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;

        Graveyard = GameObject.Find("My Graveyard");
        StartCoroutine(AfterVoidStart());
    }

    void Update()
    {
        if (z == 0)
        {
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(0, 0, 0);
            z = 1;
        }

        id = thisCard[0].id;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;

        nameText.text = "" + cardName;
        descriptionText.text = " " + cardDescription;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        returnXcards = thisCard[0].returnXcards;
        actualpower = power - hurted;

        healXpower = thisCard[0].healXpower;

        thisSprite = thisCard[0].thisImage;

        thatImage.sprite = thisSprite;

        if(this.tag == "Hand")
        {
            thisCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck-1];
            numberOfCardsInDeck -=1;
            AI.deckSize -=1;
            this.tag = "Untagged";
        }
        
        if(hurted >= power && thisCardCanBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            hurted = 0;
        }

    }

    public void BeingTarget()
    {
        isTarget = true;
    }

    public void DontBeingTarget()
    {
        isTarget = false;
    }

    IEnumerator AfterVoidStart()
    {
        yield return new WaitForSeconds(1);
        thisCardCanBeDestroyed = true;
    }
}
