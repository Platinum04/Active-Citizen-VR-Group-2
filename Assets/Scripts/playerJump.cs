using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody))]

public class playerJump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float jumpForce = 500.0f;
    public Vector3 jumpvelocity;




    //private bool IsGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f);

    public bool grounded;

    private void Awake()
    {
        if (!characterController)
            characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
       // jumpActionReference.action.performed += OnJump;
    }

    private void Update()
    {
        // grounded = IsGrounded;
        if (jumpActionReference.action.IsPressed() == true)
        {
            //jumpvelocity.y = 10f;
            characterController.Move(jumpvelocity * Time.deltaTime);

            // jetpack mode characterController.Move(Vector3.up * jumpForce * Time.deltaTime);
        }
    }

  /*  private void OnJump(InputAction.CallbackContext obj)
    {
        if (!grounded) return;
        characterController.Move(Vector3.up * jumpForce*Time.deltaTime);
        characterController.Move(Vector3.forward * (jumpForce/2)*Time.deltaTime);



    }
  */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            grounded = false;
        }
    }
}