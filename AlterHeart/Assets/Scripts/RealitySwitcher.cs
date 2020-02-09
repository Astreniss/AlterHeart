/*****************************************************************************
// File Name: RealitySwitcher.cs
// Author:
// Creation Date: 2/6/2020
//
// Brief Description:
*****************************************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealitySwitcher : MonoBehaviour
{
    public GameObject realityOne;
    public GameObject realityTwo;
    public GameObject player;

    public int version = 1;

    private int currentReality;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Swap Realities"))
        {
            if(version == 1)
            {
                print("Switching active objects");
                StartCoroutine(SwitchReality1());
            }   
            else if(version == 2)
            {
                print("Switching scenes");
                SwitchReality2();
            }
        }
    }

    private void SwitchReality2()
    {
        player.GetComponent<PlayerBehaviour>().Jump();

        if (currentReality == 1)
        {
            SceneManager.LoadScene(2);
            currentReality = 2;
        }
        else
        {
            SceneManager.LoadScene(1);
            currentReality = 1;
        }
    }

    private IEnumerator SwitchReality1()
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
