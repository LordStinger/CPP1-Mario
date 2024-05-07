using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    public int speed = 0;
    private int jumpForce = 10;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private bool isJumping = false; 
    [SerializeField] private bool isAttacking = false; 
    public Collider2D feetCollider;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (speed <= 0)
        {
            speed = 5;
            Debug.Log("Speed set to: " + speed);
        }

        if (jumpForce <= 0)
        {
            jumpForce = 10;
            Debug.Log("Jump Force: " + speed);
        }

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        Vector2 moveDirection = new Vector2(xInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;


        if (Input.GetMouseButtonDown(0))
        { 
            anim.Play("Attack");
            isAttacking = true;

            StartCoroutine(ResetIsAttacking());
        }

        if (Input.GetMouseButtonDown(0) &&  isJumping == true)
        { 
            anim.Play("AirAttack");
            isAttacking = true;

            rb.velocity += Vector2.down * 15f;

            StartCoroutine(ResetIsAttacking());
        }

        IEnumerator ResetIsAttacking()
        {
            yield return new WaitForSeconds(1f); 
            
            isAttacking = false; 

            anim.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && isAttacking == false)
        {
            Debug.Log("Space key pressed");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            //Debug.Log("Velocity Y: " + rb.velocity.y);
        }

        if (rb.velocity.y != 0 && isJumping == true && isAttacking == false)
        {
            anim.Play("Jump");
        }

        if (rb.velocity.x == 0 && isJumping == false && isAttacking == false) 
        {
            anim.Play("Idle");
            //Debug.Log("Velocity Y: " + rb.velocity.y);
        }

        if (rb.velocity.x < 0)
        {
            if (isJumping == false && isAttacking == false)
            {
                Debug.Log("Moving Left");
                anim.Play("Walk");
                anim.SetFloat("Speed", Mathf.Abs(xInput));
            }
            sr.flipX = true;
        }

        if (rb.velocity.x > 0)
        {
            if (isJumping == false && isAttacking == false)
            {
                Debug.Log("Moving Right");
                anim.Play("Walk");
                anim.SetFloat("Speed", Mathf.Abs(xInput));
            }
            sr.flipX = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isJumping == true)
        {
            isJumping = false;
        }
    }    
}
