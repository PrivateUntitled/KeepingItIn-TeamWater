using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartLevelTrigger : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterControls>())
        {
            Debug.Log(sceneName);
            StartCoroutine(AdditiveSceneManager.instance.LoadAsyncScene(sceneName));
            StartCoroutine(AdditiveSceneManager.instance.RemoveAsyncScene());
        }
    }
}
