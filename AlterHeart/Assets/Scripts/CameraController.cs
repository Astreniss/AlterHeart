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
    public Transform target;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    void LateUpdate()
    {
        
        transform.position = target.position + startPos;
    }
}
