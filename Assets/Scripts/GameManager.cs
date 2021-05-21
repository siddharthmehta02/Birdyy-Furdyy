using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject endCanvas;
    [SerializeField] private GameObject scoreCanvas;
    public static GameManager instance = null;
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    private float score = 0;
    public Text scoreText;

    public float getScore
    {
        get { return score; }
    }

    public void setScore(float value)
    {
        score += value;
        scoreText.text = Mathf.Abs(score).ToString("F0");
    }

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
        Assert.IsNotNull(scoreCanvas);
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
        scoreCanvas.SetActive(false);
        mainmenu.SetActive(true);
        endCanvas.SetActive(false);
        startCanvas.SetActive(true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
    }

    public void EnterGame()
    {
        mainmenu.SetActive(false);
        scoreCanvas.SetActive(true);
        startCanvas.SetActive(false);
        gameStarted = true;
    }
}
