using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Variable list
    public int speed = 5;
    
    public Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Function
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            Flybird();
            
        }

    }

    public void Flybird()
    {
        if (!GameManager.Instance.gameOver && GameManager.Instance.hasgamestarted)
        {
            rb.linearVelocity = new Vector3(0, speed, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //AudioManager.Instance.PlayScoreSound();
        print("entering trigger collision");
        GameManager.Instance.Score();
        Destroy(other.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!GameManager.Instance.gameOver)
        {
            GameManager.Instance.GameOver();
            
        }

        if(collision.gameObject.CompareTag("ground"))
        {

        }

        print("Collision has occured");
    }


}
