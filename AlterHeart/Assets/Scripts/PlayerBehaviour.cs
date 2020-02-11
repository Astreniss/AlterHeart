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
    public RealityController rc;

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
        bool result = false;
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, Vector3.down, out Hit, 1f))
        {
            if (Hit.transform.gameObject != null)
            {
                result = true;
            }
        }

        return result;
    }
}
