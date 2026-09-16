using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static score Instance;
    public TextMeshProUGUI text_score;
    public TextMeshProUGUI live_text;
    public static int live_num = 3;
    public static int current_score = 0;
    public PlayerMov player;
    public TextMeshProUGUI key;
    public static int keynum = 0;
    private SpriteRenderer[] spriteRenderers;
    private Collider2D Collider2D;
    private Rigidbody2D Rigidbody2D;
    private void Awake()
    {
            Instance = this;
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            Collider2D = GetComponent<Collider2D>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        text_score.text = current_score.ToString();
        live_text.text = live_num.ToString();
        key.text = keynum.ToString();
    }
    public void Score()
    {
        current_score += 1;
        text_score.text = current_score.ToString();
    }

    public void attack()
    {
            live_num -= 1;
            live_text.text = live_num.ToString();
        if(live_num <= 0)
        {
            StartCoroutine(GameoverPlay());
        
        }
       else 
        {
            player.Respawn();
        }
           
     }

 
    private IEnumerator GameoverPlay()
    {
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = false;
        }
        Collider2D.enabled = false;
        Rigidbody2D.linearVelocity = Vector2.zero;
        Rigidbody2D.simulated = false;
        this.enabled = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }
    public void Key()
    {
        keynum += 1;
        key.text = keynum.ToString();
    }
       
}

