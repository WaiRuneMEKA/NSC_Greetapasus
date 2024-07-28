using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private Animator Anime;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        Effect = GameObject.Find("EFFECT");

        Anime = Effect.GetComponent<Animator>();
        
    }

    public void ActiveArainiSkill()
    {
        if(TurnSystem.currentCoin >= 2)
        {
            TurnSystem.currentCoin -= 2;
            EnemyHealth.health -= 1;
            Anime.SetTrigger("ska1");
        }
        
    }

    public void ActiveBonekoSkill()
    {
        if (TurnSystem.currentCoin >= 2)
        {
            TurnSystem.currentCoin -= 2;
            Health.health += 1;
            Shield.shield += 1;
            Anime.SetTrigger("trh2");
        }
    }
}
