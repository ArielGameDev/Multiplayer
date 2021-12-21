using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Com.MyCompany.MyGame;

public class BeamScorer : MonoBehaviour
{
    [SerializeField]
    string m_triggerTag;
    public PlayerManager playerManager;
    public int scoreOnHit = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != m_triggerTag)
            return;
        playerManager.score += scoreOnHit; 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag != m_triggerTag)
            return;
        playerManager.score += scoreOnHit; 

    }
}
