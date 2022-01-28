using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D playerRigidbody;
    float inputX;
    float movement;


    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
      
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(inputX * movementSpeed, playerRigidbody.velocity.y);
    }

    private void InterAct()
    {
        Debug.Log("InterAction");
    }
}
