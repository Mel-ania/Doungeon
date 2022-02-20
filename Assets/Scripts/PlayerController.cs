using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float moveInput;
    private float checkRadius = 0.5f;
    private float speed = 3;
    private float jumpForce = 5;

    private int extraJumps = 0;
    private int extraJumpsValue = 1;

    private bool facingRight = true;
    private bool isGrounded = false;

    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField]
    GameObject bomb = null;
    [SerializeField]
    Transform groundCheck = null;
    [SerializeField]
    LayerMask whatIsGround = default;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        // Moving

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        // Facing left or right
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        // Jumping

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void Update()
    {
        // Jumps
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            extraJumps = extraJumpsValue;
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            anim.SetTrigger("takeOf");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Bomb
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
