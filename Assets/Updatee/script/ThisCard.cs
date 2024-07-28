using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ThisCard : MonoBehaviour
{
    public AudioSource sourceAttack1;
    public AudioClip clipAttack1;

    public AudioSource sourceShield1;
    public AudioClip clipShield1;

    public AudioSource sourceHeal1;
    public AudioClip clipHeal1;

    public AudioSource sourceHeal2;
    public AudioClip clipHeal2;

    public AudioSource sourceCoin1;
    public AudioClip clipCoin1;

    public AudioSource sourceMana1;
    public AudioClip clipMana1;

    public AudioSource sourceMuscle1;
    public AudioClip clipMuscle1;

    public AudioSource sourceLotto1;
    public AudioClip clipLotto1;

    private Animator Anime;
    public GameObject Effect;

    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    //public int addXmaxMana;

    public TMP_Text manaText;
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    CardBack CardBackScript;

    public GameObject Hand;

    public int numberOfCardsInDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject useZone;

    public static int drawX;
    public int drawXcards;
    public static int CraftX;
    public int CraftXcards;
    public int addXmaxMana;

    public GameObject AttackBorder;

    public GameObject Target;
    public GameObject Enemy;

    public bool Sickness;
    public bool cantAttack;

    public bool canAttack;

    public static bool staticTargeting;
    public static bool staticTargetingEnemy;

    public bool targeting;
    public bool targetingEnemy;

    public bool onlyThisCardAttack;

    public static bool used;

    public bool canBeDestroyed;
    public GameObject Graveyard;
    public bool beInGraveyard;

    public int hurted;
    public int actualpower;
    public int returnXcards;
    public bool useReturn;

    public static bool UcanReturn;

    public int healXpower;
    public int shieldXpower;
    public bool canHeal;

    public GameObject EnemyZone;
    public AICardToHand aiCardToHand;

    public static bool isHeal;
    public static bool isATK;

    Draggable Draggable;



    void Start()
    {
        Effect = GameObject.Find("EFFECT");

        Anime = Effect.GetComponent<Animator>();

        Draggable = GetComponent<Draggable>();
        CardBackScript = GetComponent<CardBack>();
        thisCard[0] = CardDataBase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        Sickness = true;
        used = false;

        Enemy = GameObject.Find("Player 2");

        targeting = false;
        targetingEnemy = false;

        beInGraveyard = false;

        canHeal = true;

        EnemyZone = GameObject.Find("Zone");

        isHeal = false;
        isATK = false;

        //camAnim = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        //Anime.SetTrigger("tra1");

        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        id = thisCard[0].id;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;
        //cardMana = thisCard[0].cardMana;

        manaText.text = "" + cost;
        nameText.text = "" + cardName;
        descriptionText.text = " " + cardDescription;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        returnXcards = thisCard[0].returnXcards;
        actualpower = power - hurted;

        healXpower = thisCard[0].healXpower;

        shieldXpower = thisCard[0].shieldXpower;

        thisSprite = thisCard[0].thisImage;

        thatImage.sprite = thisSprite;

        CardBackScript.UpdateCard(cardBack);

        if (this.tag == "Hand")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

        if (TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false && TurnSystem.isYourTurn == true)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        // if (canBeSummon == true)
        // {
        //     (GameObject.Find("Zone").GetComponent("DropZone") as MonoBehaviour).enabled = true;
        // }
        // else
        // {
        //     (GameObject.Find("Zone").GetComponent("DropZone") as MonoBehaviour).enabled = false;
        // }

        useZone = GameObject.Find("Zone");

        if (summoned == false && this.transform.parent == useZone.transform)
        {
            Summon();
        }

        // if (canAttack == true && beInGraveyard == false)
        // {
        //     AttackBorder.SetActive(true);
        // }
        // else
        // {
        //     AttackBorder.SetActive(false);
        // }

        // if (TurnSystem.isYourTurn == true && summoned == true)
        // {
        //     Sickness = false;
        //     cantAttack = false;
        // }

        // if (TurnSystem.isYourTurn == true && Sickness == false && cantAttack == false && used == false)
        // {
        //     canAttack = true;
        // }
        // else
        // {
        //     canAttack = false;
        // }

        // targeting = staticTargeting;
        // targetingEnemy = staticTargetingEnemy;

        // if (targetingEnemy == true)
        // {
        //     Target = Enemy;
        // }
        // else
        // {
        //     Target = null;
        // }

        // if (targeting == true && onlyThisCardAttack == true)
        // {
        //     Attack();
        // }

        // if (actualpower <= 0)
        // {
        //     Destroy();
        // }

        // if (returnXcards > 0 && summoned == true && useReturn == false && TurnSystem.isYourTurn == true)
        // {
        //     Return(returnXcards);
        //     useReturn = true;
        // }

        // if (TurnSystem.isYourTurn == false)
        // {
        //     UcanReturn = false;
        // }

        // if (canHeal == true && summoned == true)
        // {
        //     Heal();
        //     canHeal = false;
        // }

    }

    public void Summon()
    {
        if (TurnSystem.currentMana >= cost)
        {
            TurnSystem.currentMana -= cost;
            summoned = true;
            if(addXmaxMana == 0 && drawXcards == 0 && healXpower == 0 && shieldXpower ==0 )
            {
                if (power == 1)
                {
                    if (EnemyShield.shield == 0)
                    {
                        EnemyHealth.health -= 1;
                        
                        Anime.SetTrigger("tra1");
                        sourceAttack1.PlayOneShot(clipAttack1);
                        isATK = true;
                        this.Destroy();
                    }
                    if (EnemyShield.shield > 0)
                    {
                        EnemyShield.shield -= 1;
                        
                        Anime.SetTrigger("tra1");
                        sourceAttack1.PlayOneShot(clipAttack1);
                        isATK = true;
                        this.Destroy();
                    }
                }
                if (power == 2)
                {
                    if(EnemyShield.shield == 0)
                    {
                        EnemyHealth.health -= 2;
                        
                        this.Destroy();
                    }
                    if (EnemyShield.shield > 0)
                    {
                        EnemyShield.shield -= 2;
                        
                        this.Destroy();
                    }
                }
            }
            if (addXmaxMana == 4 )
            {
                Health.health -= 1;
                TurnSystem.currentCoin += TurnSystem.maxCoin;
                TurnSystem.currentMana += TurnSystem.maxMana;
                Anime.SetTrigger("trl1");
                sourceLotto1.PlayOneShot(clipLotto1);
                this.Destroy();
            }
            if (addXmaxMana == 3 )
            {
                EnemyHealth.health -= 1;
                Anime.SetTrigger("trmu1");
                sourceMuscle1.PlayOneShot(clipMuscle1);
                this.Destroy();
            }
            if (addXmaxMana == 2)
            {
                TurnSystem.currentCoin += 1;
                Anime.SetTrigger("trc1");
                sourceCoin1.PlayOneShot(clipCoin1);
                Destroy();
            }
            if (addXmaxMana == 1)
            {
                MaxMana(addXmaxMana);
                Anime.SetTrigger("trm1");
                sourceMana1.PlayOneShot(clipMana1);
                Destroy();
            }
            if( drawXcards > 0)
            {
                drawX = drawXcards;
                Destroy(GameObject.Find("AICard(Clone)"));
                this.Destroy();
            }
            if (healXpower > 0)
            {
                Heal();
                if(id == 2)
                {
                    
                    Anime.SetTrigger("trh1");
                    sourceHeal1.PlayOneShot(clipHeal1);
                }
                if (id == 7)
                {
                    TurnSystem.currentCoin += 1;
                    
                    Anime.SetTrigger("trh2");
                    sourceHeal2.PlayOneShot(clipHeal2);
                }
                Destroy();
            }
            if (shieldXpower > 0)
            {
                ShieldX();
                Anime.SetTrigger("trsh1");
                sourceShield1.PlayOneShot(clipShield1);
                Destroy();
            }

            //if (id == 1)
            //{
            //    
            //    Anime.SetTrigger("tra1");
            //}
        }
    }

    public void MaxMana(int x)
    {
        TurnSystem.currentMana += x;
    }

    public void Attack()
    {
        if (canAttack == true && summoned == true)
        {
            if (Target != null)
            {
                if (Target == Enemy)
                {
                    

                    if (EnemyShield.shield == 0)
                    {
                        //camAnim.SetTrigger("Shake");

                        EnemyHealth.health -= power;
                        targeting = false;
                        canAttack = true;
                        Sickness = true;
                        used = true;
                    }
                    if (EnemyShield.shield > 0)
                    {
                        //camAnim.SetTrigger("Shake");

                        EnemyShield.shield -= power;
                        targeting = false;
                        canAttack = true;
                        Sickness = true;
                        used = true;
                    }

                }
                if (used == true)
                {
                    Destroy(gameObject);
                    used = false;

                }
            }
        }


    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;
    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }

    public void Destroy()
    {
        Destroy(Draggable);
        Graveyard = GameObject.Find("My Graveyard");
        canBeDestroyed = true;
        if (canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;
            hurted = 0;
        }
        //if (id == 1)
        //{
        //    Anime.SetTrigger("tra1");
        //}
    }

    public void Return(int x)
    {
        for (int i = 0; i <= x; i++)
        {
            ReturnCard();
        }
    }

    public void ReturnCard()
    {
        UcanReturn = true;
    }

    public void ReturnThis()
    {
        if (beInGraveyard == true && UcanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            UcanReturn = false;
            beInGraveyard = false;
            Sickness = true;
        }
    }

    public void ShieldX()
    {
        Shield.shield += shieldXpower;
        isHeal = true;
    }

    public void Heal()
    {
        Health.health += healXpower;
        isHeal = true;
    }

    IEnumerator CraftBeta()
    {
        if( id == 0 && id == 1 )
        {
            Destroy();
            // Destroy(GameObject.Find("CardToHand(Clone)"));
            yield return new WaitForSeconds(1);
            Destroy();
            // Destroy(GameObject.Find("CardToHand(Clone)"));
            yield return new WaitForSeconds(1);
            CraftX = 1;
        }
        

    }
    public void CraftBeta2()
    {
        StartCoroutine(CraftBeta());
    }

}