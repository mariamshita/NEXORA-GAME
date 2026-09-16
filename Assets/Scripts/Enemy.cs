using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody2D;

    public float min_x;
    public float max_x;
    private bool move_right = true;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if (move_right)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + Vector2.right * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(1, 1, 1);

            if (transform.position.x >= max_x)
            {
                move_right = false;
            }
        }
        else
        {
            rigidbody2D.MovePosition(rigidbody2D.position + Vector2.left * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(-1, 1, 1);

            if (transform.position.x <= min_x)
            {
                move_right = true;
            }
        }
    }
}