using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtongracePeriod;

    //private Transform cameraTransform;
    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        //cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Character movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtongracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Time.time - jumpButtonPressedTime <= jumpButtongracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        //Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        //Vector3 moveDirection = (cameraForward * verticalInput + cameraTransform.right * horizontalInput).normalized;
        //characterController.Move(moveDirection * speed * Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementDirection, Vector3.up), rotationSpeed * Time.deltaTime);

        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
