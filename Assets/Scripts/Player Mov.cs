using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerMov : MonoBehaviour
{
    public float speed = 5;
    public float jump_force = 7;
    public AudioClip player_attack;
    private Rigidbody2D Rigidbody2D;
    private bool on_ground = true;
    private Animator animator;
    private Vector3 start_position;
    private SpriteRenderer[] spriteRenderers;
    private cameraMov camera;
    private Collider2D Collider2D;
    public AudioClip checkpoint_audio;
    public AudioClip Jumping_audio;
   // public AudioClip run;
    
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.freezeRotation = true;
        animator = GetComponent<Animator>();
        start_position = transform.position;
        camera = GetComponent<cameraMov>();
        Collider2D = GetComponent<Collider2D>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float mov_x = 0;
        if (Keyboard.current.rightArrowKey.isPressed)
        {
           // AudioSource.PlayClipAtPoint(run, transform.position);
            mov_x += 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
           // AudioSource.PlayClipAtPoint(run, transform.position);
            mov_x -= 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        bool is_running = mov_x != 0;
        animator.SetBool("isRunning" , is_running);
        
        Rigidbody2D.linearVelocity = new Vector2(mov_x * speed, Rigidbody2D.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && on_ground)
        {
            AudioSource.PlayClipAtPoint(Jumping_audio, transform.position);
            Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, jump_force);
            on_ground = false;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("takeOff");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        on_ground = true;
        animator.SetBool("isJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(player_attack, transform.position);
            animator.SetTrigger("stun");
            if (score.Instance != null)
            {
                score.Instance.attack();
            }
        }

        if (collision.gameObject.CompareTag("checkpoints"))
        {
            AudioSource.PlayClipAtPoint(checkpoint_audio, transform.position);
            start_position = collision.transform.position;
        }
    }
    public void Respawn()
    {
        StartCoroutine(respawn());
    }

    private IEnumerator respawn()
    {
     
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = false;
        }
        Collider2D.enabled = false;
        Rigidbody2D.linearVelocity = Vector2.zero;
        Rigidbody2D.simulated = false;
        this.enabled = false;

        
        yield return new WaitForSeconds(1.5f);

       
        transform.position = start_position;
        Rigidbody2D.linearVelocity = Vector2.zero;
        Rigidbody2D.simulated = true;
        on_ground = true;
        animator.SetBool("isRunning", false);
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = true;
        }
        Collider2D.enabled = true;
        this.enabled = true;
       
    }

   
}