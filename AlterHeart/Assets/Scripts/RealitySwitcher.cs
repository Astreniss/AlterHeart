/*****************************************************************************
// File Name: RealitySwitcher.cs
// Author:
// Creation Date: 2/6/2020
//
// Brief Description:
*****************************************************************************/

using System.Collections;
using UnityEngine;

public class RealitySwitcher : MonoBehaviour
{
    public GameObject realityOne;
    public GameObject realityTwo;
    public GameObject player;

    private int currentReality;

    private void Start()
    {
        currentReality = 1;
    }

    void Update()
    {
        if (Input.GetButtonDown("Swap Realities"))
        {
            StartCoroutine(SwitchReality());
        }

    }

    private IEnumerator SwitchReality()
    {
        player.GetComponent<PlayerBehaviour>().Jump();
        yield return new WaitForSeconds(.2f);
        player.GetComponent<Rigidbody>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody>().useGravity = false;

        if (currentReality == 1)
        {
            currentReality = 2;
            realityOne.SetActive(false);
            realityTwo.SetActive(true);
        }
        else
        {
            currentReality = 1;
            realityOne.SetActive(true);
            realityTwo.SetActive(false);
        }
        yield return new WaitForSeconds(.5f);
        player.GetComponent<Rigidbody>().useGravity = true;

    }
}
