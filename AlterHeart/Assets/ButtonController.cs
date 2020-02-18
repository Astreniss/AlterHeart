using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPushed;
    public GameObject activationObject;

    // Start is called before the first frame update
    void Start()
    {
        isPushed = false;
        activationObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PushButton()
    {
        if(!isPushed)
        {
            isPushed = true;
            Debug.Log("Button Pushed ");
            activationObject.SetActive(false);
        }
    }
}
