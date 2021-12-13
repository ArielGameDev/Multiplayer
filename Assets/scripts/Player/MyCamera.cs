using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MyCamera : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            gameObject.GetComponent<Camera>().enabled = true;
            gameObject.GetComponent<AudioListener>().enabled = true;
        }   
    }
}
