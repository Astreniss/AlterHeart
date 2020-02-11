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
    public GameObject objectRealityOne;
    public GameObject objectRealityTwo;

    public Transform teleportRealityOne;
    public Transform teleportRealityTwo;
    private Vector3 teleportDistance;

    public GameObject player;

    public int version = 1;

    private int currentReality;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        teleportDistance = teleportRealityTwo.position - teleportRealityOne.position;
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
            else if (version == 3)
            {
                print("Teleporting");
                SwitchReality3();
            }
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
            objectRealityOne.SetActive(false);
            objectRealityTwo.SetActive(true);
        }
        else
        {
            currentReality = 1;
            objectRealityOne.SetActive(true);
            objectRealityTwo.SetActive(false);
        }
        yield return new WaitForSeconds(.5f);
        player.GetComponent<Rigidbody>().useGravity = true;

    }

    //Switches reality by Switching scenes
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

    //Switches reality by teleporting
    private void SwitchReality3()
    {
        player.GetComponent<PlayerBehaviour>().Jump();

        Vector3 newPos = player.transform.position;

        

        if (currentReality == 1)
        {
            currentReality = 2;
            newPos -= teleportDistance;
        }
        else
        {
            currentReality = 1;
            newPos += teleportDistance;
        }

        player.transform.position = newPos;
    }

    
}
