using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SphereCollider>() || other.GetComponent<CharacterControls>())
        {
            // add point
            GameManager.instance.points++;
            Destroy(this.gameObject);
        }
    }
}
