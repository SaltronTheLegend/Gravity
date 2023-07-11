using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject referenceIndicator;

    private Vector3 referenceDirection;

    private void Update()
    {
        // Detect arrow key inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Change the character's reference direction
            referenceDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            // Show a hologram or indicator of the character's reference direction
            referenceIndicator.transform.rotation = Quaternion.LookRotation(referenceDirection);
            referenceIndicator.SetActive(true);
        }
        else
        {
            // Hide the reference indicator when no arrow keys are pressed
            referenceIndicator.SetActive(false);
        }

        // Detect Enter key press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Manipulate gravity based on the selected direction
            ManipulateGravity();
        }
    }

    private void ManipulateGravity()
    {
        // Modify the physics settings or apply a custom gravity force to objects in the scene based on the reference direction
        Physics.gravity = referenceDirection * 9.8f;
        Debug.Log("Gravity manipulated in the " + referenceDirection + " direction!");
    }
}