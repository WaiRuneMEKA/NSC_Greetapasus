using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public bool hasbeenplayed;

    public int handindex;

    GameManager gm;

    private void start()
    {
        //    gm = findobjectoftype<GameManager>();
        //    //anim = getcomponent<animator>();
        //    //camanim = camera.main.getcomponent<animator>();
        //}

        //private void onmousedown()
        //{
        //    if (!hasbeenplayed)
        //    {
        //        //instantiate(hollowcircle, transform.position, quaternion.identity);

        //        //camanim.settrigger("shake");
        //        //anim.settrigger("move");

        //        transform.position += vector3.up * 3f;
        //        hasbeenplayed = true;
        //        gm.availablecardslots[handindex] = true;
        //        invoke("movetodiscardpile", 2f);
        //    }
        //}

        //void movetodiscardpile()
        //{
        //    //instantiate(effect, transform.position, quaternion.identity);
        //    gm.discardpile.add(this);
        //    gameobject.setactive(false);
        //}
    }
}
