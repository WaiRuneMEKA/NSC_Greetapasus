using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public int drawXcards;
    public int addXmaxMana;

    public Sprite thisImage;

    public int returnXcards;

    public int healXpower;

    public int shieldXpower;

    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Power, string CardDescription, Sprite ThisImage, int DrawXcards, int AddXmaxMana, int ReturnXcards, int HealXpower, int ShieldXpower)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription=CardDescription;

        thisImage = ThisImage;

        drawXcards = DrawXcards;
        addXmaxMana = AddXmaxMana;

        returnXcards = ReturnXcards;

        healXpower = HealXpower;

        shieldXpower = ShieldXpower;

    }

}
