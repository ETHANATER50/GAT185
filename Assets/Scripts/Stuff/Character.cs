using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.8f;

    public Animator animator;

    public Weapon weapon;


    CharacterController characterController;
    Vector3 inputDirection;
    Vector3 velocity;
    private bool onGround;
    Health health { get; set; }


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();

    }


    void Update()
    {

        if (onGround && velocity.y < 0)
        {
            velocity.y = 0;
        }



        animator.SetFloat("Speed", inputDirection.magnitude);
        animator.SetBool("onGround", onGround);
        animator.SetFloat("VelocityY", velocity.y);


        onGround = characterController.isGrounded;

        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion rotation = Quaternion.AngleAxis(cameraRotation.eulerAngles.y, Vector3.up);
        Vector3 direction = rotation * inputDirection;

        if (inputDirection.magnitude > 0.1f)
        {
            //transform.forward = inputDirection.normalized;

            Quaternion target = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, (speed * 0.7f) * Time.deltaTime);
        }


        characterController.Move(direction * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (health.health <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    public void OnJump()
    {
        if (onGround)
        {
            velocity.y += jump;
        }
    }

    public void OnFire()
    {
        weapon.Fire(transform.forward);
        Debug.Log("Fire!");
    }

    public void OnPunch()
    {
        animator.SetTrigger("Punch");
    }

    public void OnThrow()
    {
        animator.SetTrigger("Throw");
    }

    public void OnMove(InputValue input)
    {
        var v2 = input.Get<Vector2>();
        inputDirection = Vector3.zero;
        inputDirection.x = v2.x;
        inputDirection.z = v2.y;
    }
}
