using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_panel;
    private void Awake()
    {
        Pause_panel.SetActive(false);
    }

    public void Pause()
    {
        Pause_panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Pause_panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        score.live_num = 3;
        score.keynum = 0;
        score.current_score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

}
