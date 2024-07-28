using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    //public AudioSource source;
    //public AudioClip clip;

    public static bool isYourTurn;
    public static int yourTurn;
    public int yourOpponentTurn;
    public Text turnText;

    public static int maxMana;
    public static int currentMana;
    public Text manaText;

    public static int maxCoin;
    public static int currentCoin;
    public Text CoinText;

    public static bool startTurn;
    public static bool startAITurn;

    public int random;

    public bool turnEnd;
    public Text timerText;
    public static int seconds;
    public static bool timerStart;

    public static int maxEnemyMana;
    public static int currentEnemyMana;
    public Text enemyManaText;

    public static int TurnCount;
    public TMP_Text TurnCountText;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        
        seconds = 60;
        timerStart = true;

        TurnCount = 1;
        //TurnCountText = 1;
        TurnCountText.text = "Turn : " + TurnCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
            // ThisCardAI.enemyUseCard = true;
        }

        manaText.text = currentMana+"/"+maxMana;
        CoinText.text = currentCoin+"/"+maxCoin;

        if(isYourTurn == true && seconds > 0 && timerStart == true)
        {
            StartCoroutine(Timer());
            timerStart = false;
        }

        if(seconds == 0 && isYourTurn == true)
        {
            EndYourTurn();
            timerStart = true;
            seconds = 60;
        }

        timerText.text = seconds + "";

        if(isYourTurn == false && seconds > 0 && timerStart == true)
        {
            StartCoroutine(EnemyTimer());
            timerStart = false;
        }

        if(seconds == 0 && isYourTurn == false)
        {
            EndYourOpponentTurn();
            timerStart = true;
            seconds = 60;
        }

        enemyManaText.text = currentEnemyMana + "/" + maxEnemyMana;
        
    }

    public void EndYourTurn()
    {
        TurnCount++;
        Debug.Log(TurnCount);
        TurnCountText.text = "Turn : " + TurnCount.ToString();

        isYourTurn = false;
        yourOpponentTurn +=1;

        maxEnemyMana += 1;
        currentEnemyMana = maxEnemyMana;

        startAITurn = true;
        ThisCardAI.enemyUseCard = true;

        
        
        RestartTime();
    }

    public void EndYourOpponentTurn()
    {
        isYourTurn = true;
        yourTurn +=1;

        maxMana +=1;
        currentMana = maxMana;

        maxCoin +=1;
        currentCoin = maxCoin;

        startTurn = true;

        TurnCount ++;
        Debug.Log(TurnCount);

        RestartTime();

        
    }

    public void StartGame()
    {
        random = Random.Range(0,0);
        if(random == 0)
        {
            isYourTurn = true;
            yourTurn = 1;
            yourOpponentTurn = 0;

            maxMana = 1;
            currentMana =1;

            maxCoin = 1;
            currentCoin =1;

            maxEnemyMana = 0;
            currentEnemyMana = 0;

            startTurn = false;
        }

        if(random == 1)
        {
            isYourTurn = false;
            yourTurn = 0;
            yourOpponentTurn = 1;

            maxMana = 0;
            currentMana = 0;

            maxCoin = 0;
            currentCoin =0;

            maxEnemyMana = 1;
            currentEnemyMana = 1;

            startAITurn = false;
        }
    }

    //while(currentTime >= 0)
    //{
    //     source.PlayOneShot(clip);
    //     countdownText.text = currentTime.ToString();
    //     yield return new WaitForSeconds(1f);
    //     currentTime--;
    // }
    // source.PlayOneShot(clipEnd);

    IEnumerator Timer()
    {
        if(isYourTurn == true && seconds > 0)
        {
            //while(seconds <= 55)
            //{
            //    source.PlayOneShot(clip);
                
            //}
            yield return new WaitForSeconds(1);
            seconds --;
            StartCoroutine(Timer());


        }
    }

    IEnumerator EnemyTimer()
    {
        if(isYourTurn == false && seconds > 0)
        {
            yield return new WaitForSeconds(1);
            seconds --;
            StartCoroutine(EnemyTimer());
        }
    }
    public void RestartTime()
    {
        seconds = 60;
        timerStart = true;
    }
}
