using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SphereCollider>())
        {
            SceneManager.LoadScene("EndScene_Lvl2");
        }
    }
}
