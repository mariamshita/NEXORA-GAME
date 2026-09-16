using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioClip audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(score.Instance != null)
            {
                AudioSource.PlayClipAtPoint(audio, transform.position);
                score.Instance.Key();
            }
            Destroy(gameObject);
        }
    }
}
