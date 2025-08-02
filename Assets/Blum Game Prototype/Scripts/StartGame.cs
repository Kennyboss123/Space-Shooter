using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] public Button startGameBtn;
    [SerializeField] public Button creditsBtn;
    [SerializeField] public Button quitGameBtn;
    [SerializeField] public Button backBtn;

    [SerializeField] public GameObject startingScreen;
    [SerializeField] public GameObject creditsScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        RegisterButtons();
    }
    void RegisterButtons()
    {
        startGameBtn.onClick.AddListener(() => OnStartGame());
        creditsBtn.onClick.AddListener(() => OnCreditsButton());
        quitGameBtn.onClick.AddListener(() => OnQuitGame());
        backBtn.onClick.AddListener(() => OnBackButton());
    }
    public void OnStartGame()
    {
        GameManagerTest.instance.LoadGameScene();
    }
    public void OnCreditsButton()
    {
        startingScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void OnBackButton()
    {
        creditsScreen.SetActive(false);
        startingScreen.SetActive(true);
    }
    void OnQuitGame()
    {
        GameManagerTest.instance.QuitGame();
        Debug.Log("Game has ended");
    }
}
