using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Com.MyCompany.MyGame;

public class Shield : MonoBehaviour
{
    public PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerManager>().Health += 0.5f;
        Destroy(gameObject);
    }
}
