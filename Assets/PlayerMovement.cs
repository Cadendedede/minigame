using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 8f;
    float walkSpeed = 8f;
    float sprintSpeed = 14f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    float stamina = 100f;
    float maxStamina = 100f;

    float number;

    public Slider slider;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        number = sprintSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= 10f * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (stamina <= maxStamina)
            {
                stamina += 1f * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (stamina <= maxStamina)
            {
                stamina += 1f * Time.deltaTime;
            }
        }
        else
        {
            if (stamina <= 100)
            {
                stamina += 7f * Time.deltaTime;
            }
        }

        if (stamina <= 0f)
        {
            sprintSpeed = walkSpeed;
        }
        else
        {
            sprintSpeed = number;
        }

        slider.value = stamina;

        if (stamina < 100)
        {
            slider.gameObject.SetActive(true);
        }
        else
        {
            slider.gameObject.SetActive(false);
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if(Input.GetKey (KeyCode.LeftShift) && moveZ == 1)
                speed = sprintSpeed;
            else
                speed = walkSpeed;
        }


        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


    }
        }


