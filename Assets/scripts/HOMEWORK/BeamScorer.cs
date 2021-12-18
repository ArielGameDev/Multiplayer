using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Com.MyCompany.MyGame;

public class BeamScorer : MonoBehaviour
{

    public PlayerManager playerManager;
    public int scoreOnHit = 1;

    private void OnTriggerEnter(Collider other)
    {
        playerManager.score += scoreOnHit; 
    }

    private void OnTriggerStay(Collider other)
    {
        playerManager.score += scoreOnHit; 

    }
}
