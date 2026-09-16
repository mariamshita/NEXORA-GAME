using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas;

    public void Play()
    {
        score.current_score = 0;
        score.live_num = 3;
        score.keynum = 0;
        SceneManager.LoadScene("Level 1");
    }

    public void Exit()
    {
        Application.Quit();
       
    }
    public void Restart()
    {
        score.live_num = 3;
        score.keynum = 0;
        score.current_score = 0;
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
}

