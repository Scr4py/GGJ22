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
    [SerializeField] private PaulFX sound;

    private Rigidbody2D playerRigidbody;
    float inputX;
    float movement;
    bool isGrounded;
    public bool isArtist;
    private Animator animator;

    private void OnEnable()
    {
        EventManager.useButton += UseButton;
    }

    private void OnDisable()
    {
        EventManager.useButton -= UseButton;
    }

    private void UseButton()
    {
        animator.SetTrigger("UseButton");
    }

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
            AudioManager.Instance.PlayJumpSound();
            //animator.SetTrigger("Jumped");
            animator.SetBool("isJumping", true);


            animator.SetBool("isFalling", false);

        }

        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheckCenter.transform.position, groundCheckRadius, groundLayer);
        if (hitCollider)
        {
            isGrounded = true;
            animator.SetBool("isFalling", false);
        }
        if (playerRigidbody.velocity.y < 0.0f)
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (isArtist ? (artistFasterFallMulti - 1) : (fasterFallMulti - 1)) * Time.deltaTime;
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);

        }
        else if (playerRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (isArtist ? (artistLowFallMulti - 1) : (lowFallMulti - 1)) * Time.deltaTime;
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", true);


        }
        else if (playerRigidbody.velocity.y > 0.1f)
        {
            animator.SetBool("isJumping", true);

        }
        else
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);

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
            AudioManager.Instance.PlaySoundOneTime(sound);
            EventManager.F_SwitchEvent();
            EventManager.F_SwitchWorld(isArtist ? World.ArtWorld : World.ProggerWorld);
            EventManager.F_SwitchBackground(isArtist);
        }


        if (!isGrounded && playerRigidbody.velocity.y > 0.03f)
        {
            Debug.Log("Macht das!");
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
        else if (inputX < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (inputX == 0)
        {
            // animator.SetBool("isFalling", false);
            animator.SetBool("isIdle", true);
        }
        else
        {
            animator.SetBool("isIdle", false);

        }

        //else if(playerRigidbody.velocity.x <= 0)


        gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, transform.position.y);
    }

    private void FixedUpdate()
    {
        //playerRigidbody.velocity = new Vector2(inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, playerRigidbody.velocity.y);
        //gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * (isArtist ? artistMovementSpeed : movementSpeed) * Time.deltaTime, transform.position.y);
    }

    private void InterAct()
    {
        Debug.Log("InterAction");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckCenter.transform.position, new Vector3(groundCheckCenter.transform.position.x, groundCheckCenter.transform.position.y - groundCheckRadius, groundCheckCenter.transform.position.z));
    }


    public void StartPush()
    {
        animator.SetBool("isPushing", true);
    }

    public void StopPush()
    {
        animator.SetBool("isPushing", false);
    }
}
