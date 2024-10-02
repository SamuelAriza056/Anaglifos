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

    [Header("Canvas References")]
    public GameObject canvas;
    [SerializeField] GameObject redPanel;
    [SerializeField] GameObject bluePanel;
    [SerializeField] bool redPanelOn;
    [SerializeField] int randomInitialPanel;

    [Header("Platform Parameters")]
    public GameObject redGroup;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        randomInitialPanel = Random.Range(0, 1);
        if(randomInitialPanel == 0) { redPanelOn = true; }
        else { redPanelOn = false; }
    }

    // Update is called once per frame
    void Update()
    {
        if (redPanelOn)
        {
            redPanel.SetActive(true);
            bluePanel.SetActive(false);
        }
        else
        {
            redPanel.SetActive(false);
            bluePanel.SetActive(true);
        }
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
        if (context.started) { redPanelOn = !redPanelOn; }
    }
}
