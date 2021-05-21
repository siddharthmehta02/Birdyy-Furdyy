using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject endCanvas;
    public static GameManager instance = null;
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
        Assert.IsNotNull(mainmenu);
        Assert.IsNotNull(startCanvas);
        Assert.IsNotNull(endCanvas);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void PlayerCollided()
    {
        gameOver = true;
        endCanvas.SetActive(true);
    }

    public void MainMenu()
    {
        gameOver = false;
        playerActive = false;
        gameStarted = false;
        mainmenu.SetActive(true);
        endCanvas.SetActive(false);
        startCanvas.SetActive(true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
    }

    public void EnterGame()
    {
        mainmenu.SetActive(false);
        startCanvas.SetActive(false);
        gameStarted = true;
    }
}
