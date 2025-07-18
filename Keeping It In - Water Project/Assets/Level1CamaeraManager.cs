using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1CamaeraManager : MonoBehaviour
{
    [System.Serializable]
    public struct CameraLevel
    {
        public Transform levelTransform;
        public int level;
        public float yLevel;
    }

    public CameraLevel[] cameraPositions;
    public Camera cam;
    public float camSpeed;
    private float desiredCameraLevel;
    private float timeBeforeDeletion = 3f;

    private void Start()
    {
        desiredCameraLevel = cam.transform.position.y;
    }

    private void Update()
    {
        if (cam.transform.position.y > desiredCameraLevel)
        {
            Debug.Log("Test");
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - camSpeed * Time.deltaTime, cam.transform.position.z);
        }

        if (cam.transform.position.y <= cameraPositions[cameraPositions.Length - 1].yLevel)
        {
            //SceneManager.LoadScene("EndScene_Lvl_1");
            if (GameManager.instance.points >= 5)
            {

                if (!AdditiveSceneManager.instance.isLoading)
                {
                    StartCoroutine(AdditiveSceneManager.instance.LoadAsyncScene("EndScene_Lvl_1"));
                    StartCoroutine(AdditiveSceneManager.instance.RemoveAsyncScene());
                }
            }
            else
            {
                if (!AdditiveSceneManager.instance.isLoading)
                {
                    GameManager.instance.points = 0;
                    StartCoroutine(AdditiveSceneManager.instance.LoadAsyncScene("Level1"));
                    StartCoroutine(AdditiveSceneManager.instance.RemoveAsyncScene());
                }
            }
        }
    }

    public void UpdateCameraLevel(int level)
    {
        foreach(CameraLevel camLevel in cameraPositions)
        {
            if(camLevel.level == level)
            {
                desiredCameraLevel = camLevel.yLevel;

                List<GameObject> allBlocks = new List<GameObject>();

                for(int i = 0; i < camLevel.levelTransform.childCount; i++)
                {
                    allBlocks.Add(camLevel.levelTransform.GetChild(i).gameObject);
                }

                StartCoroutine(BlocksToPass(allBlocks));
                break;
            }
        }
    }

    private IEnumerator BlocksToPass(List<GameObject> blocksToRaise)
    {
        float currentTime = 0f;

        while(currentTime <= timeBeforeDeletion)
        {
            foreach(GameObject block in blocksToRaise)
            {
                if (block)

                block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y + camSpeed * Time.deltaTime, block.transform.position.z);
            }

            yield return null;
            currentTime += Time.deltaTime;
        }
    }
}
