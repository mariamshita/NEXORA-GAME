using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDoor : MonoBehaviour
{
    public GameObject c_door;
    public GameObject o_door;
    private bool is_open = false;
    public GameObject levelPassedText;
    private bool is_loading = false;
    public int requiredKeys1 = 1;
    public int requiredKeys2 = 2;

    private void Awake()
    {
        c_door.SetActive(true);
        o_door.SetActive(false);
        levelPassedText.SetActive(false);
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (score.Instance != null && score.keynum == requiredKeys1)
        {
            if (! is_open)
            {
                open_door();
               // SceneManager.LoadScene("Level2");
            }
        }
        if (score.Instance != null && score.keynum == requiredKeys2)
        {
            if (!is_open)
            {
                open_door();
                // SceneManager.LoadScene("Level2");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
       
            if (is_open && !is_loading)
            {
                close_door();
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
       
            if (score.Instance != null && score.keynum == requiredKeys1 && !is_loading)
            {
                is_loading = true;
                open_door();

                StartCoroutine(LoadNextLevel());

            }


            else if (score.Instance != null && score.keynum == requiredKeys2 && !is_loading)
            {
            is_loading = true;
            open_door();

            StartCoroutine(LoadVictoryl());

            }




    }

    private IEnumerator LoadVictoryl()
    {
        yield return new WaitForSeconds(0.3f);
        levelPassedText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        levelPassedText.SetActive(false);
        SceneManager.LoadScene("Victory");
    }

  
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(0.3f);
        levelPassedText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        levelPassedText.SetActive(false);
        SceneManager.LoadScene("Level2");
    }

    private void open_door()
    {
        is_open = true;
        c_door.SetActive(false);
        o_door.SetActive(true);
    }

    private void close_door()
    {
        is_open = false;
        c_door.SetActive(true);
        o_door.SetActive(false);
    }
}
