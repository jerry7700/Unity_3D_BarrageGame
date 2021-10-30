using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrller : MonoBehaviour
{
    public float speed;
    public float x_min, x_max, z_min, z_max;
    public float tilt;
    private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vericalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * speed, 0, vericalInput * speed);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, x_min, x_max), rb.position.y, Mathf.Clamp(rb.position.z, z_min, z_max));

        rb.rotation = Quaternion.Euler(0, 0, -(tilt * rb.velocity.x));
    }
}
