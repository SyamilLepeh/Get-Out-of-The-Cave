using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 startPos;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private int jumpCount = 0; //Untuk lompat dua kali
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f; //Bahagian lompat
    [SerializeField] private GameObject HoldC;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource playerHit;
    [SerializeField] private AudioSource itemCollected;
    [SerializeField] private AudioSource powerJumping;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Bahagian Jalan dan Lompat
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpCount < 2)) // Bahagian Lompat
        {
            jumpSoundEffect.Play(); // Jangan ambil, ini untuk tambah lagu
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
        UpdateAnimationUpdate(); // Jangan ambil, ini untuk animasi
        SuperJump(); // Jangan ambil, ini untuk kuasa lompat
    }


    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }

    private bool IsGrounded() //Bahagian Lompat
    {
        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround))
        {
            jumpCount = 0; // Reset jump count when grounded
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            playerHit.Play();
            Die();
            HeartSystem.health -= 1;
        }
        if (collision.gameObject.CompareTag("JumpItem"))
        {
            itemCollected.Play();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = startPos;
        anim.SetTrigger("alive");
        UpdateAnimationUpdate();
    }

    public void SuperJump()
    {
        if (PowerSystem.powerBar == 5)
        {
            HoldC.SetActive(true);
            if (Input.GetKeyDown(KeyCode.C))
            {
                powerJumping.Play();
                HoldC.SetActive(false);
                StartCoroutine(JumpChange(3f));
                
            }
        }
    }

    IEnumerator JumpChange(float man)
    {
        
        jumpForce += 10;
        yield return new WaitForSeconds(man);
        HoldC.SetActive(false);
        jumpForce -= 10;
        PowerSystem.powerBar = 0;

    }
}
