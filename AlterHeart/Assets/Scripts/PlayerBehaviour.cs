/*****************************************************************************
// File Name: PlayerBehaviour.cs
// Author:
// Creation Date: 2/6/2020
//
// Brief Description:
*****************************************************************************/

using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed;
    public float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Movement();
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Movement()
    {

    }

    public void Jump()
    {
        if (OnGround())
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

    }

    private bool OnGround()
    {
        return true;
    }
}
