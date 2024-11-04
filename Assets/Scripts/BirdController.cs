using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    public float forceAmount = 1f;
    public float rotationSpeed = 5f;
    public float reboundForceHorizontal = 10f;
    public float reboundForceVertical = 10f;
    public float forwardForce = 1f;
    public float backwardForce = 1f;
    private Rigidbody rb;
    private BirdControls controls;
    private Vector2 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new BirdControls();
        controls.Gameplay.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => movementInput = Vector2.zero;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Update()
    {
        if (movementInput.y > 0)
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }
        else if (movementInput.y < 0)
        {
            rb.AddForce(Vector3.down * forceAmount, ForceMode.Impulse);
        }

        if (movementInput.x > 0)
        {
            rb.AddForce(Vector3.right * forwardForce, ForceMode.Impulse);
        }
        else if (movementInput.x < 0)
        {
            rb.AddForce(Vector3.left * backwardForce, ForceMode.Impulse);
        }

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpperObstacle"))
        {
            rb.AddForce(new Vector3(-reboundForceHorizontal, -reboundForceVertical, 0), ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("LowerObstacle"))
        {
            rb.AddForce(new Vector3(-reboundForceHorizontal, reboundForceVertical, 0), ForceMode.Impulse);
        }
    }
}
