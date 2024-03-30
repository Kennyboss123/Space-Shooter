using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameManager>().ResetGame();
    }    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGameOverScene()
    {
        StartCoroutine(waitForsecs()); 
    }
    IEnumerator waitForsecs()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(2);
    }    

    public void QuitGame()
    {
        Application.Quit();
    }
}
