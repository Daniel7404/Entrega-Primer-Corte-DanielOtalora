using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] int numAnimals;



    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void nivel2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void nivel3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        //pausar y "despausar" el juego
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
        //setActive
        //variable serializada
    }

    public void CaptureAnimal()
    {
        numAnimals--;
        if(numAnimals < 1)
        {
            //ganamos!
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
    }
}
