using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class CutsceneManager : MonoSingleton<CutsceneManager>
{
    [SerializeField] private GameObject cam;
    [SerializeField] private Camera endingCutscene;
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;

    private void Start()
    {
        endingCutscene.gameObject.SetActive(false);
        //endingCutscene.GetComponent<PlayableDirector>().stopped += (a) => { PointChoiceManager.instance.ShowChoice(); };
    }

    public void SwitchToCutscene()
    {
        cam.SetActive(false);
        endingCutscene.gameObject.SetActive(true);

        foreach (CinemachineVirtualCamera virtualCamera in virtualCameras)
            virtualCamera.gameObject.SetActive(true);
    }
}
