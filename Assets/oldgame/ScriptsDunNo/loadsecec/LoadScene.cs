using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

      

    public void StartButton(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));

    }

    IEnumerator  LoadLevel(string sceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}

