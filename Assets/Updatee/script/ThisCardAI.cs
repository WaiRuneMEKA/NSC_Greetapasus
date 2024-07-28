using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ThisCardAI : MonoBehaviour
{
    //ScriptAPartToUse Name = new ScriptAPartToUse();
    private Animator Anime;
    public GameObject Effect;



    public List<Card> thisCard = new List<Card> ();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

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
    public int addXmaxMana;

    public GameObject AttackBorder;
    public GameObject back;

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

    public static bool enemyUseCard;

    public int usecount;

    



    void Start()
    {
        Effect = GameObject.Find("EFFECT");

        Anime = Effect.GetComponent<Animator>();

        CardBackScript = GetComponent<CardBack>();
        thisCard[0] = CardDataBase.cardList[thisId];
        numberOfCardsInDeck = AIDeck.deckSize;

        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        Sickness = true;
        used = false;

        Enemy = GameObject.Find("Player 1");

        targeting = false;
        targetingEnemy = false;

        beInGraveyard = false;

        canHeal = true;

        EnemyZone = GameObject.Find("Zone");

        isHeal = false;
        enemyUseCard = true;

        usecount = 1;
    }

    void Update()
    {
        Hand = GameObject.Find("EnemyHand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        id = thisCard[0].id;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;

        manaText.text = "" + cost;
        nameText.text = " " + cardName;
        descriptionText.text = " " + cardDescription;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        returnXcards = thisCard[0].returnXcards;
        actualpower = power - hurted;

        healXpower = thisCard[0].healXpower;

        shieldXpower = thisCard[0].shieldXpower;

        thisSprite = thisCard[0].thisImage;

        thatImage.sprite = thisSprite;

        // CardBackScript.UpdateCard(cardBack);

        if(this.tag == "Hand")
        {
            thisCard[0] = AIDeck.staticDeck[numberOfCardsInDeck-1];
            numberOfCardsInDeck -=1;
            AIDeck.deckSize -=1;
            cardBack = false;
            this.tag = "Untagged";
        }

        // if(TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false && TurnSystem.isYourTurn == true)
        // {
        //     canBeSummon = true;
        // }
        // else 
        // {
        //     canBeSummon = false;
        // }

        // if(canBeSummon == true)
        // {
        //     (GameObject.Find("Zone").GetComponent( "DropZone" ) as MonoBehaviour).enabled = true;
        // }
        // else
        // {
        //     (GameObject.Find("Zone").GetComponent( "DropZone" ) as MonoBehaviour).enabled = false;
        // }
        
        useZone = GameObject.Find("Zone");

        // if(summoned == false && this.transform.parent == useZone.transform)
        // {
        //     Summon();
        // }

        // if(canAttack == true && beInGraveyard == false)
        // {
        //     AttackBorder.SetActive(true);
        // }
        // else
        // {
        //     AttackBorder.SetActive(false);
        // }

        // if(TurnSystem.isYourTurn == true && summoned == true)
        // {
        //     Sickness = false;
        //     cantAttack = false;
        // }

        // if(TurnSystem.isYourTurn == true && Sickness == false && cantAttack == false && used == false)
        // {
        //     canAttack = true;
        // }
        // else
        // {
        //     canAttack = false;
        // }

        // targeting = staticTargeting;
        // targetingEnemy = staticTargetingEnemy;

        // if(targetingEnemy == true)
        // {
        //     Target = Enemy;
        // }
        // else
        // {
        //     Target = null;
        // }

        // if(targeting == true && onlyThisCardAttack == true)
        // {
        //     Attack();
        // }

        // if(actualpower <= 0)
        // {
        //     Destroy();
        // }

        // if(returnXcards > 0 && summoned == true && useReturn == false && TurnSystem.isYourTurn == true)
        // {
        //     Return(returnXcards);
        //     useReturn = true;
        // }

        // if(TurnSystem.isYourTurn == false)
        // {
        //     UcanReturn = false;
        // }

        // if(canHeal == true && summoned == true)
        // {
        //     Heal();
        //     canHeal = false;
        // }
        if (TurnSystem.isYourTurn == false && TurnSystem.currentEnemyMana <= 0)
        {
            EndYourOpponentTurn();
        }

        if (TurnSystem.isYourTurn == false && TurnSystem.seconds == 39)
        {
            EndYourOpponentTurn();
        }
        
        if( TurnSystem.isYourTurn == false && enemyUseCard == true && TurnSystem.seconds == 55 && TurnSystem.currentEnemyMana == TurnSystem.maxEnemyMana )
        {
            GameObject.Find("AICard(Clone)").transform.SetParent(useZone.transform);
            GameObject.Find("AICard(Clone)").name = "1" + usecount;
            usecount++;
            enemyUseCard = false;
            
        }
        if ( TurnSystem.isYourTurn == false && enemyUseCard == false && TurnSystem.seconds == 54 && TurnSystem.currentEnemyMana > 0 )
        {
            enemyUseCard = true;
        }
        if( TurnSystem.isYourTurn == false && enemyUseCard == true && TurnSystem.seconds == 50 && TurnSystem.currentEnemyMana > 0 )
        {
            GameObject.Find("AICard(Clone)").transform.SetParent(useZone.transform);
            GameObject.Find("AICard(Clone)").name = "1" + usecount;
            usecount++;
            enemyUseCard = false;
        }

        if ( TurnSystem.isYourTurn == false && enemyUseCard == false && TurnSystem.seconds == 49 && TurnSystem.currentEnemyMana > 0 )
        {
            enemyUseCard = true;
        }

        if( TurnSystem.isYourTurn == false && enemyUseCard == true && TurnSystem.seconds == 45 && TurnSystem.currentEnemyMana > 0 )
        {
            GameObject.Find("AICard(Clone)").transform.SetParent(useZone.transform);
            GameObject.Find("AICard(Clone)").name = "1" + usecount;
            usecount++;
            enemyUseCard = false;
        }

        if ( TurnSystem.isYourTurn == false && enemyUseCard == false && TurnSystem.seconds == 44 && TurnSystem.currentEnemyMana > 0)
        {
            enemyUseCard = true;
        }

        if( TurnSystem.isYourTurn == false && enemyUseCard == true && TurnSystem.seconds == 40 && TurnSystem.currentEnemyMana > 0 )
        {
            GameObject.Find("AICard(Clone)").transform.SetParent(useZone.transform);
            GameObject.Find("AICard(Clone)").name = "1" + usecount;
            usecount++;
            enemyUseCard = false;
        } 

        


        if ( this.transform.parent == useZone.transform )
        {
            back.SetActive(false);
            Summon();
            Destroy();
        }

        
        















    }

    public void Summon()
    {
            TurnSystem.currentEnemyMana -= cost;
            summoned = true;
            if(addXmaxMana == 0 && drawXcards == 0 && healXpower == 0 && shieldXpower ==0 )
            {
                if (power == 1)
                {
                    if (Shield.shield == 0)
                    {
                        Health.health -= 1;
                        Debug.Log("kuy");
                        Anime.SetTrigger("tra1");
                        this.Destroy();
                    }
                    if (Shield.shield > 0)
                    {
                        Shield.shield -= 1;
                        Debug.Log("kuy");
                        Anime.SetTrigger("tra1");
                        this.Destroy();
                    }
                }
                if (power == 2)
                {
                    if(Shield.shield == 0)
                    {
                        Health.health -= 2;
                        this.Destroy();
                    }
                    if (Shield.shield > 0)
                    {
                        Shield.shield -= 2;
                        this.Destroy();
                    }

                }
            }
            if( addXmaxMana == 1)
            {
                drawX = drawXcards;
                this.Destroy();
            }
            if( addXmaxMana == 2)
            {
                TurnSystem.currentEnemyMana += 1;
                this.Destroy();
            }
            if (addXmaxMana == 3 )
            {
                Health.health -= 1;
                Anime.SetTrigger("trmu1");
                this.Destroy();
            }
            if (addXmaxMana == 4)
            {
                this.Destroy();
            }
            if( drawXcards > 0)
            {
                drawX = drawXcards;
                Destroy(GameObject.Find("CardToHand(Clone)"));
                this.Destroy();
            }
            if ( healXpower > 0)
            {
                Heal();
                Debug.Log("kuy");
                Anime.SetTrigger("trh1");
                this.Destroy();   
            }
            if ( shieldXpower > 0)
            {
                ShieldX();
                Anime.SetTrigger("trsh1");
                this.Destroy();   
            }

    }

    

    public void MaxMana(int x)
    {
        TurnSystem.currentEnemyMana += x;
    }

    // public void Attack()
    // {
    //     if(canAttack == true && summoned == true)
    //     {
    //         if(Target != null)
    //         {
    //             if(Target == Enemy)
    //             {
    //                 Health.health -= power;
    //                 targeting = false;
    //                 canAttack = true;
    //                 Sickness = true;
    //                 used = true;
                    
    //             }
    //             if(used == true)
    //             {
    //                 Destroy(gameObject);
    //                 used = false;
                    
    //             }
    //         }
    //     }
        

    // }

    // public void UntargetEnemy()
    // {
    //     staticTargetingEnemy = false;
    // }
    // public void TargetEnemy()
    // {
    //     staticTargetingEnemy = true;
    // }
    // public void StartAttack()
    // {
    //     staticTargeting = true;
    // }
    // public void StopAttack()
    // {
    //     staticTargeting = false;
    // }
    // public void OneCardAttack()
    // {
    //     onlyThisCardAttack = true;
    // }
    // public void OneCardAttackStop()
    // {
    //     onlyThisCardAttack = false;
    // }

    public void Destroy()
    {
        Graveyard = GameObject.Find("My Graveyard");
        canBeDestroyed = true;
        if(canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;
            hurted = 0;
        }
    }

    public void Return(int x)
    {
        for(int i = 0; i <= x; i++)
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
        if(beInGraveyard == true && UcanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            UcanReturn = false;
            beInGraveyard = false;
            Sickness = true;
        }
    }

    public void Heal()
    {
        EnemyHealth.health += healXpower;
        isHeal = true;
    }

    public void ShieldX()
    {
        EnemyShield.shield += shieldXpower;
        isHeal = true;
    }

    public void AttackPhase()
    {
        GameObject.Find("11").transform.SetParent(useZone.transform);
        // GameObject.Find("10").transform.parent = useZone.transform;
        this.CardBackScript.UpdateCard(cardBack);
        enemyUseCard = false;
    }
    public void EndYourOpponentTurn()
    {
        TurnSystem.isYourTurn = true;
        TurnSystem.yourTurn +=1;

        TurnSystem.maxMana +=1;
        TurnSystem.currentMana = TurnSystem.maxMana;

        TurnSystem.maxCoin +=1;
        TurnSystem.currentCoin = TurnSystem.maxCoin;

        TurnSystem.startTurn = true;
        RestartTime();
    }

    public void RestartTime()
    {
        TurnSystem.seconds = 60;
        TurnSystem.timerStart = true;
    }

}
