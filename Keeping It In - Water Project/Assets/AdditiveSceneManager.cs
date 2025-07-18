using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class AdditiveSceneManager : Singleton<AdditiveSceneManager>
{
    [HideInInspector] public UnityEvent onLoadComplete;
    public bool isLoading = false;
    private string currentAdditiveScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncScene("HeartRoom"));
    }

    public IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        isLoading = true;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        isLoading = false;

        currentAdditiveScene = sceneName;
        Debug.Log("Scene Loaded");

        onLoadComplete.Invoke();
    }

    public IEnumerator RemoveAsyncScene()
    {
        AsyncOperation asyncRemove = SceneManager.UnloadSceneAsync(currentAdditiveScene);

        // Wait until the asynchronous scene fully loads
        while (!asyncRemove.isDone)
        {
            yield return null;
        }

        Debug.Log("Removed Scene");
    }
}
