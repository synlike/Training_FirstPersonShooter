using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;
    private bool crouching;
    private bool sprinting;

    public float gravity = -9.8f;
    public float speed = 5.0f;
    public float jumpHeight = 3.0f;

    public float crouchDuration = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;

        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2.0f;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;

        if(crouching)
        {

            StartCoroutine(DoCrouch(1, crouchDuration));
            speed /= 2f;
        }
        else
        {

            StartCoroutine(DoCrouch(2, crouchDuration));
            speed *= 2f;
        }
    }

    private IEnumerator DoCrouch(float endValue, float duration)
    {
        float time = 0f;
        float startValue = controller.height;

        while(time < duration)
        {
            controller.height = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        controller.height = endValue;
    }

    public void Sprint()
    {
        sprinting = !sprinting;

        if(sprinting)
        {
            speed *= 1.5f;
        }
        else
        {
            speed /= 1.5f;
        }
    }
}
