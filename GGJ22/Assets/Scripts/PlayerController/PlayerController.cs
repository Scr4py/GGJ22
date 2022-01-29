using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float artistMovementSpeed;
    [SerializeField] private float artistJumpForce;
    [SerializeField] private float artistFasterFallMulti;
    [SerializeField] private float artistLowFallMulti;
    [SerializeField] private float fasterFallMulti;
    [SerializeField] private float lowFallMulti;




    [SerializeField] private GameObject groundCheckCenter;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRigidbody;
    float inputX;
    float movement;
    bool isGrounded;
    public bool isArtist;
    private Animator animator;



    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isArtist = true;
        animator.SetBool("isArtist", isArtist);
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // playerRigidbody.AddForce(new Vector2(0, isArtist ? artistJumpForce : jumpForce), ForceMode2D.Impulse);
            playerRigidbody.velocity = Vector2.up * (isArtist ? artistJumpForce : jumpForce);
            isGrounded = false;
            animator.SetTrigger("Jumped");
            animator.SetBool("isFalling", false);

        }

        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheckCenter.transform.position, groundCheckRadius, groundLayer);
        if (hitCollider)
        {
            Debug.Log("isGrounded: " + isGrounded);
            isGrounded = true;
            animator.SetBool("isFalling", false);
        }
        if (playerRigidbody.velocity.y < 0.0f)
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (isArtist ? (artistFasterFallMulti - 1) : (fasterFallMulti - 1)) * Time.deltaTime;
            animator.SetBool("isFalling", true);
        }
        else if (playerRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (isArtist ? (artistLowFallMulti - 1) : (lowFallMulti - 1)) * Time.deltaTime;
            animator.SetBool("isFalling", false);

        }
        else
        {
            animator.SetBool("isFalling", false);

        }


        if (Input.GetButtonDown("Switch"))
        {
            Debug.Log(isArtist);
            if (!isArtist)
            {
                isArtist = true;
                animator.SetBool("isArtist", isArtist);
            }
            else
            {
                isArtist = false;
                animator.SetBool("isArtist", isArtist);

            }
            EventManager.F_SwitchEvent();
        }
        if (!isGrounded && playerRigidbody.velocity.y > 0.3f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * (isArtist ? artistMovementSpeed / 3 : movementSpeed / 3) * Time.deltaTime, transform.position.y);

        }
        else
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, transform.position.y);
        }
        if (inputX > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        //else if(playerRigidbody.velocity.x <= 0)
        else if (inputX < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);

        }
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, transform.position.y);
    }

    private void FixedUpdate()
    {
        //playerRigidbody.velocity = new Vector2(inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, playerRigidbody.velocity.y);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, transform.position.y);
    }

    private void InterAct()
    {
        Debug.Log("InterAction");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckCenter.transform.position, new Vector3(groundCheckCenter.transform.position.x, groundCheckCenter.transform.position.y - groundCheckRadius, groundCheckCenter.transform.position.z));
    }
}
