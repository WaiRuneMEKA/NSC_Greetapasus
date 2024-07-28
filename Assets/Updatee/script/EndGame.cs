using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Text victoryText;
    public GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health.health <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "";
            StartCoroutine(LoseGameWait());

        }
        if(EnemyHealth.health <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "";
            StartCoroutine(WinGameWait());

        }
        
    }

    IEnumerator WinGameWait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoseGameWait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
