using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Com.MyCompany.MyGame;
using System;

public class LargerBeams : MonoBehaviour
{
    public PlayerManager playerManager;
    [SerializeField] private float TimeOfPower;
    private float activateTime;
    private bool powerUp;
    private Vector3 beamScale;
    private Collider obj;

    void Start()
    {
        activateTime = 0;
        powerUp = false;
        beamScale = playerManager.gameObject.transform.localScale;
    }
    
    private void Update()
    {
        activateTime += Time.deltaTime;
        if (powerUp)
        {
            if (activateTime >= TimeOfPower)
            {
                obj.gameObject.GetComponent<PlayerManager>().beams.transform.localScale = beamScale;
                Destroy(gameObject);
            }
            else Debug.Log(activateTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !powerUp)
        {
            other.gameObject.GetComponent<PlayerManager>().beams.transform.localScale = beamScale * 2f;
            obj = other;
            Debug.Log("power taken");
            powerUp = true;
            activateTime = 0;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
