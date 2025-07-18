using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterControls>())
        {
            SceneManager.LoadScene("EndScene_Lvl_3");
        }
    }
}
