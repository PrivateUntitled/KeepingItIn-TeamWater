using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<CharacterControls>())
        {
            Destroy(collision.gameObject);
            //CutsceneManager.instance.SwitchToCutscene();
        }
    }
}
