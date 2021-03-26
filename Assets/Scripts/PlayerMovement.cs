/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    [SerializeField] private float forwardMoveSpeed = 7.5f;
    [SerializeField] private float backwardMoveSpeed = 3f;
    [SerializeField] private float turnSpeed = 150f;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed : backwardMoveSpeed;
            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }
        
    
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    [SerializeField] private float forwardMoveSpeed = 7.5f;
    [SerializeField] private float rightMoveSpeed = 4f;
    [SerializeField] private float leftMoveSpeed = -4f;
    [SerializeField] private float backwardMoveSpeed = 3f;
    [SerializeField] private float turnSpeed = 150f;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var aim = Input.GetAxis("Mouse X");
        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, aim * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed : backwardMoveSpeed;
            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }
        if (horizontal != 0)
        {
            float moveSpeedToUse;
            if(vertical > 0) {
                moveSpeedToUse = (horizontal > 0) ? rightMoveSpeed : leftMoveSpeed;
            }
            else
            {
                moveSpeedToUse = (horizontal > 0) ? leftMoveSpeed/2 : rightMoveSpeed/2;
            }
         
            characterController.SimpleMove(transform.right * moveSpeedToUse * vertical);
        }

    }
}

