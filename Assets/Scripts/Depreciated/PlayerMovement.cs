using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    private static bool inputEnabled = true;

    private InputBindings input;
    private Rigidbody body;

    private void Start()
    {
        input = InputBindings.CreateWithDefaultBindings();
        body = GetComponent<Rigidbody>();
    }

	private void Update()
    {
        if(input.ActiveDevice != null && inputEnabled)
        {
            //To handle the actual movement
            int moveDirection = 0;
            if (input.Up.IsPressed)
            {
                moveDirection = 1;
            }
            else if (input.Down.IsPressed)
            {
                moveDirection = -1;    
            }
            body.AddForce(transform.forward * moveSpeed * moveDirection);
            //Rotating the player
            int rotationDirection = 0;
            if (input.Right.IsPressed)
            {
                rotationDirection = 1;
            }
            else if (input.Left.IsPressed)
            {
                rotationDirection = -1;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationDirection, transform.eulerAngles.z), Time.deltaTime * rotateSpeed);
        }
    }
}
