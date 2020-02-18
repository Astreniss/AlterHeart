/*****************************************************************************
// File Name: CameraController.cs
// Author:
// Creation Date: 2/6/2020
//
// Brief Description:
*****************************************************************************/

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Texture2D cursorTexture;
  //  public Texture2D cursorTextureSelected;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public LayerMask raycastLayer;
    public float spherecastRadius = 1f;

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    private Vector3 startPos;

    private void Start()
    {
        Cursor.visible = false;
        //startPos = transform.position;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, raycastLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }

        // Spherecast to determine object hit
        if (Physics.SphereCast(transform.position, spherecastRadius, transform.forward, out hit, Mathf.Infinity, raycastLayer, QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log("Hovering Over Button ");

            if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                if(hit.collider.GetComponent<ButtonController>() != null)
                {
                    hit.collider.GetComponent<ButtonController>().PushButton();
                }
            }
            
            //Debug.Log(hit.collider.isTrigger);  
        }
    }


    void LateUpdate()
    {
        
        //transform.position = playerBody.position + startPos;
    }
}
