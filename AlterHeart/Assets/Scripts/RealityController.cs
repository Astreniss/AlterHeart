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

    public Light myLighting;
    public Color r1Light;
    public Color r2Light;

    private void Start()
    {
        currentReality = 1;

        myLighting.color = r1Light;
        DimensionOnePoints = GameObject.FindGameObjectsWithTag("DimensionOnePoints");
        DimensionTwoPoints = GameObject.FindGameObjectsWithTag("DimensionTwoPoints");
    }

    void Update()
    {
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
            float lowestDist = 1000000;

            for (int i = 0; i < DimensionOnePoints.Length; i++)
            {
                float thisDist = DimensionOnePoints[i].GetComponent<TeleportPoints>().CompareDistance(player.transform.position);
                Debug.Log("thisDist A: " + thisDist);

                if (thisDist < lowestDist)
                {
                    lowestDist = thisDist;
                    Debug.Log("A " + lowestDist);
                    result = DimensionOnePoints[i].GetComponent<TeleportPoints>().partner.transform.position;
                }
            }
        }
        else if(currentReality == 2)
        {
            float lowestDist = 1000000;

            for (int i = 0; i < DimensionTwoPoints.Length; i++)
            {
                float thisDist = DimensionTwoPoints[i].GetComponent<TeleportPoints>().CompareDistance(player.transform.position);
                Debug.Log("thisDist B: " + thisDist);

                if (thisDist < lowestDist)
                {
                    lowestDist = thisDist;

                    Debug.Log("B " + lowestDist);
                    result = DimensionTwoPoints[i].GetComponent<TeleportPoints>().partner.transform.position;
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

        newPos = ClosestPoint();
        player.transform.position = newPos;

        if (currentReality == 1)
        {
            currentReality = 2;
            myLighting.color = r2Light;
        }
        else if(currentReality == 2)
        {
            currentReality = 1;
            myLighting.color = r1Light;
        }
    }
}
