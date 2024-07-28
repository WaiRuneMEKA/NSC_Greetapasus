using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();

    void Awake()
    {
        //attack
        cardList.Add (new Card (0,"Foot Attack", 1, 1, "Deal 1 damage ", Resources.Load <Sprite>("1"), 0, 0, 0, 0, 0));

        cardList.Add (new Card (1,"Very Good", 1, 1, "Gain 1 shield ", Resources.Load <Sprite>("3"), 0, 0, 0, 0, 1));

        cardList.Add (new Card (2,"Bandage", 1, 1, "Heal 1 HP", Resources.Load <Sprite>("6"), 0, 0, 0, 1, 0));

        cardList.Add (new Card (3,"Muscle Form", 1, 1, " Deal 1 HP directly!", Resources.Load <Sprite>("10"), 0, 3, 0, 0, 0));

        cardList.Add (new Card (4,"Sweet drink", 0, 1, "Gain 1 mana ", Resources.Load <Sprite>("9"), 0, 1, 0, 0, 0));

        cardList.Add (new Card (5, "Lotto Bean", 0, 1, " -1 HP To Get Power! ", Resources.Load<Sprite>("11"), 0, 4, 0, 0, 0));

        cardList.Add (new Card (6, "Rich Of Card", 0, 1, "Gain 1 coin ", Resources.Load<Sprite>("8"), 0, 2, 0, 0, 0));

        cardList.Add (new Card (7,"Healing Baguatte", 1, 1, "Gain 1 coin and HP", Resources.Load <Sprite>("7"), 0, 0, 0, 1, 0));

        cardList.Add (new Card (8,"Fart Attack", 2, 2, "Deal 2 damages ", Resources.Load <Sprite>("2"), 0, 0, 0, 0, 0));
             
        cardList.Add (new Card (9, "Very Very Good", 2, 1, "Gain 2 shields ", Resources.Load <Sprite>("4"), 0, 0, 0, 0, 2));
        
        cardList.Add (new Card (10, "Steal!", 1, 1, "Steal opponent 1 Card ", Resources.Load <Sprite>("5"), 1, 0, 0, 0, 0));
        
    }
}