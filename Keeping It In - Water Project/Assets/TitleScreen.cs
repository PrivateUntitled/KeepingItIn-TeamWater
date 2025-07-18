using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject titleScreen;

    public void Start()
    {
        Cursor.visible = true;
    }


    public void PlayGame()
    {
        Destroy(platform);
        titleScreen.SetActive(false);
        Cursor.visible = false;
    }

    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
