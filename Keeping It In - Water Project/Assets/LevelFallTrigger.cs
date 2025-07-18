using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFallTrigger : MonoBehaviour
{
    public int levelTrigger;
    public Level1CamaeraManager level1CamaeraManager;

    private void OnTriggerEnter(Collider other)
    {
        level1CamaeraManager.UpdateCameraLevel(levelTrigger);
    }
}
