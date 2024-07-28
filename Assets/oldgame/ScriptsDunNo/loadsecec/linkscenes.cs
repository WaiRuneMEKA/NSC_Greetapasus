using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class linkscenes : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator  LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
