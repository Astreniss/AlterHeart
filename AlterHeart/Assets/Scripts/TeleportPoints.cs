/*****************************************************************************
// File Name: TeleportPoints.cs
// Author:
// Creation Date: 
//
// Brief Description:
*****************************************************************************/
using UnityEngine;

public class TeleportPoints : MonoBehaviour
{
    public GameObject partner;
    public Vector3 location;

    private void Start()
    {
        location = transform.position;
    }
}
