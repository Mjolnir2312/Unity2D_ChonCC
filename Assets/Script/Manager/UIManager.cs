using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private AudioClip GameOverSound;

    private void Awake()
    {
        GameOverScreen.SetActive(false);
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(GameOverSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
        
    }
}
