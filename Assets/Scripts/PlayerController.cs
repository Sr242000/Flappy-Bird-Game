using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only allow flying input if the game has started and is not over
        if (GameManager.Instance.hasgamestarted && !GameManager.Instance.gameOver)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
            {
                Flybird();
            }
        }
    }

    public void Flybird()
    {
        if (!GameManager.Instance.gameOver && GameManager.Instance.hasgamestarted)
        {
            rb.linearVelocity = new Vector2(0, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Instance.gameOver && GameManager.Instance.hasgamestarted)
        {
            GameManager.Instance.Score();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.Instance.gameOver)
        {
            GameManager.Instance.GameOver();

            if (collision.gameObject.CompareTag("ground"))
            {
                Debug.Log("Collision has occurred");
            }
        }
    }
}
