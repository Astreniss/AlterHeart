/*****************************************************************************
// File Name: RealityController.cs
// Author:
// Creation Date: 2/6/2020
//
// Brief Description:
*****************************************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealityController : MonoBehaviour
{
    public Transform teleportRealityOne;
    public Transform teleportRealityTwo;
    //private Vector3 teleportDistance;

    public GameObject player;

    private int currentReality = 1;
    private GameObject[] DimensionOnePoints;
    private GameObject[] DimensionTwoPoints;

    private float shortestDistanceA = 0f;
    private float shortestDistanceB = 0f;

    private void Start()
    {
        currentReality = 1;

        shortestDistanceA = 1000000;
        shortestDistanceB = 1000000;

        //teleportDistance = teleportRealityTwo.position - teleportRealityOne.position;
        DimensionOnePoints = GameObject.FindGameObjectsWithTag("DimensionOnePoints");
        DimensionTwoPoints = GameObject.FindGameObjectsWithTag("DimensionTwoPoints");
    }

    void Update()
    {
        Debug.Log("A" + shortestDistanceA); 
        Debug.Log("B" + shortestDistanceA);

        if (Input.GetButtonDown("Swap Realities"))
        {
            SwitchReality();
        }
    }

    //Decides which TeleportPoint in the current dimension is closest
    private Vector3 ClosestPoint()
    {
        Vector3 result = Vector3.zero;

        if(currentReality == 1)
        {
            //float lowestDist = 1000000;

            shortestDistanceA = 1000000;

            for (int i = 0; i < DimensionOnePoints.Length; i++)
            {
                
                float thisDist = DimensionOnePoints[i].GetComponent<TeleportPoints>().CompareDistance(player.transform.position);

                if(thisDist <= shortestDistanceA)
                {
                    shortestDistanceA = thisDist;
                    result = DimensionOnePoints[i].GetComponent<TeleportPoints>().partner.transform.position;
                }
            }
        }
        else if(currentReality == 2)
        {
            //float lowestDist = 1000000;

            shortestDistanceB = 1000000;

            for (int i = 0; i < DimensionTwoPoints.Length; i++)
            {
                float thisDist = DimensionTwoPoints[i].GetComponent<TeleportPoints>().CompareDistance(player.transform.position);

                if (thisDist <= shortestDistanceB)
                {
                    shortestDistanceB = thisDist;

                    result = DimensionTwoPoints[i].GetComponent<TeleportPoints>().partner.transform.position;
                        
                        //transform.position;
                }
            }
        }

        return result;
    }

    //Switches reality by teleporting
    private void SwitchReality()
    {
        player.GetComponent<PlayerBehaviour>().Jump();
        
        Vector3 newPos = player.transform.position;

        if (currentReality == 1)
        {
            currentReality = 2;            
        }
        else
        {
            currentReality = 1;
        }
        newPos = ClosestPoint();
        player.transform.position = newPos;
    }

    
}
