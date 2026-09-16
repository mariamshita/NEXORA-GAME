using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class coin : MonoBehaviour
{

    public AudioClip Coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(Coin, transform.position);

            if(score.Instance != null)
            {
                score.Instance.Score();
            }
            Destroy(gameObject);
        }
    }

}
