using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
   

    [SerializeField] private GameObject groundCheckCenter;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRigidbody;
    float inputX;
    float movement;
    bool isGrounded;


    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheckCenter.transform.position, groundCheckRadius, groundLayer);
        if (hitCollider)
        {
            Debug.Log("isGrounded: " + isGrounded);
            isGrounded = true;
        }
      

    }

    private void FixedUpdate()
    {
        //playerRigidbody.velocity = new Vector2(inputX * movementSpeed, playerRigidbody.velocity.y);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + inputX * movementSpeed * Time.deltaTime, transform.position.y);
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
