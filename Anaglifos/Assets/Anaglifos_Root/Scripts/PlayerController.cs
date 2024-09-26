using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Referencias Privadas
    Rigidbody playerRb;
    PlayerInput playerInput;
    Vector2 moveInput;

    [Header("Player Parameters")]
    public float speed;
    public float jumpForce;
    [SerializeField] bool isGrounded;

    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed,playerRb.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Transform pos = collision.transform;

            if (pos.position.y < transform.position.y)
            {
                isGrounded = true;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            isGrounded = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnSpecialAction(InputAction.CallbackContext context)
    {
     
    }
}
