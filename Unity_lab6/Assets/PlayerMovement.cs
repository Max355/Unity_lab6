using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    BoxCollider2D boxCollider;
    Rigidbody2D rbody;

  
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);   
        rbody.velocity = movementVector;
        Run(); 
        Jump();   
    }

    void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rbody.velocity.x) > Mathf.Epsilon;
    }

    void Jump()
    {
        bool playerHasVerticalSpeed = Mathf.Abs(rbody.velocity.y) > Mathf.Epsilon;
    }

    void Update()
    {
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
           return;
        }
        if (Input.GetButtonDown("Jump"))
        {
           rbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}
