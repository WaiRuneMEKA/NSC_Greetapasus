using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<Cards> deck;
	//public List<Card> discardPile;

	public Transform[] cardSlots;
	public bool[] availableCardSlots;

	public Text deckSizeText;
	//public Text discardPileSizeText;

	public void DrawCard()
	{
		if (deck.Count >= 1)
		{
			Cards randomCard = deck[Random.Range(0, deck.Count)];

			for (int i = 0; i < availableCardSlots.Length; i++)
			{
				if (availableCardSlots[i] == true)
				{
					randomCard.gameObject.SetActive(true);
					//randomCard.handIndex = i;

					randomCard.transform.position = cardSlots[i].position;
					//randomCard.hasBeenPlayed = false;

					deck.Remove(randomCard);
                    availableCardSlots[i] = false;
                    return;
				}
			}
		}
	}

    //public void Shuffle()
    //{
    //    if (discardPile.Count >= 1)
    //    {
    //        foreach (Card card in discardPile)
    //        {
    //            deck.Add(card);
    //        }
    //        discardPile.Clear();
    //    }
    //}

    private void Update()
	{
		deckSizeText.text = deck.Count.ToString();
		//discardPileSizeText.text = discardPile.Count.ToString();
	}
}
