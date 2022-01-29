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
    bool isArtist;




    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.AddForce(new Vector2(0, isArtist ? artistJumpForce : jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheckCenter.transform.position, groundCheckRadius, groundLayer);
        if (hitCollider)
        {
            Debug.Log("isGrounded: " + isGrounded);
            isGrounded = true;
        }
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (isArtist ? (artistFasterFallMulti - 1) : (fasterFallMulti - 1)) * Time.deltaTime;
        }
        else if (playerRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (isArtist ? (artistLowFallMulti - 1) : (lowFallMulti - 1)) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Switch"))
        {
            Debug.Log(isArtist);
            if (!isArtist)
            {
                isArtist = true;
            }
            else
            {
                isArtist = false;
            }
            EventManager.F_SwitchEvent();
        }
    }

    private void FixedUpdate()
    {
        //playerRigidbody.velocity = new Vector2(inputX * movementSpeed, playerRigidbody.velocity.y);
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
