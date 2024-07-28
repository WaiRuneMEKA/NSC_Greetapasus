using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dialogText;




    //ได้รับการ์ด draw

    string draw1 = "I will win with this card.";  
    string draw2 = "Oh, this card isn't bad.";
    string draw3 = "More...More!!"; 

    //ได้คราฟการ์ด Craft

    string Craft1 = "Hmm, this one is very good.";
    string Craft2 = "Ah, I like this one.";
    string Craft3 = "This card will make me win.";

    //ได้เล่นการ์ดบัพ  bulf

    string bulf1 = "Ah, this is good.";
    string bulf2 = "I'm strong!!";
    string bulf3 = "I feel a little better.";

    //ได้โจมตี attack

    string attack1 = "Take it!!";
    string attack2 = "Are you hurt?";
    string attack3 = "You die!!";

    //โดนโจมตี attacked

    string attacked1 = "It hurts!!";
    string attacked2 = "Why did you do that?";
    string attacked3 = "OUCH!!";

    //ชนะ win

    string win1 = "I won haha";
    string win2 = "You are too weak";
    string win3 = "See you next life";

    //แพ้ lose
    string lose1 = "Whyyyy";
    string lose2 = "Next time I will take revenge.";
    string lose3 = "I hate this game";
    
    
/////////////////////////////////////////////////////////////////////////////

    
    

    
    void Start()
    {
        dialogText.text = "start this game!!";
        StartCoroutine(waitGoBack());
    }

    // Update is called once per frame
    void Update() 
    {
        if (ThisCard.isHeal == true)    //ตัวแปรที่ที่ถ้าเกิดขึ้นจะเกิด dialog
        {
            Pickbulf();                //ใส่textที่จะสุ่ม
            
            ThisCard.isHeal = false;
            StartCoroutine(waitGoBack());

        }
        if (ThisCardSteal.isDraw == true)
        {
            Pickdraw();

            ThisCardSteal.isDraw = false;
            StartCoroutine(waitGoBack());

        }
        if (ThisCard.isATK == true)
        {
            Pickdraw();
            
            ThisCard.isATK = false;
            StartCoroutine(waitGoBack());

        }
        // if (ThisCard.isHeal == true)
        // {
        //     dialogText.text = "Heal!";
        //     ThisCard.isHeal = false;
        // }
        
    }

    IEnumerator waitGoBack() //หน่วงเวลา
    {
        yield return new WaitForSeconds(5);
        dialogText.text = "";
    }
    


    /////////////////////////////////////////////////////////////////////////////////////////// สุ้มตึงๆ
    private void Pickdraw() 
    {                                                                  //ตั้งชื่อการ์ดแรนดม
        string[] playdraw = new string[] { draw1, draw2, draw3 };      //ใส่ชื่อที่จะสุ่ม
        string randomName = playdraw[Random.Range(0, playdraw.Length)];//ใส่ว่าจะสุ่มด้านบนอะไรบ้าง เริ่มที่0
        dialogText.text = randomName;                                  //text ขึ้นออกมา
    }

    private void PickCraft() 
    {
        string[] playCraft = new string[] { Craft1, Craft2, Craft3 };
        string randomName = playCraft[Random.Range(0, playCraft.Length)];
        dialogText.text = randomName;
    }

    private void Pickbulf() 
    {
        string[] playbulf = new string[] { bulf1, bulf2, bulf3 };
        string randomName = playbulf[Random.Range(0, playbulf.Length)];
        dialogText.text = randomName;
    }

    private void Pickattak() 
    {
        string[] playattak = new string[] { attack1, attack2, attack3 };
        string randomName = playattak[Random.Range(0, playattak.Length)];
        dialogText.text = randomName;
    }

    private void Pickattaked() 
    {
        string[] playattaked = new string[] { attacked1, attacked2, attacked3 };
        string randomName = playattaked[Random.Range(0, playattaked.Length)];
        dialogText.text = randomName;
    }

    private void Pickwin() 
    {
        string[] playwin = new string[] { win1, win2, win3 };
        string randomName = playwin[Random.Range(0, playwin.Length)];
        dialogText.text = randomName;
    }

    private void Picklose() 
    {
        string[] playlose = new string[] { lose1, lose2, lose3 };
        string randomName = playlose[Random.Range(0, playlose.Length)];
        dialogText.text = randomName;
    }
    
}
