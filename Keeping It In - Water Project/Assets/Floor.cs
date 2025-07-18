using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private float warningTime;
    [SerializeField] private float dissapearTime;
    [SerializeField] private float shakeDiff;
    [SerializeField] private float shakeSpeed;
    [SerializeField] private Level1Manager levelManager;
    private bool isFloorDespawning = false;
    public int level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterControls>())
        {
            GameManager.instance.points++;
            //PointChoiceManager.instance.points++;
            if (!isFloorDespawning)
            {
                StartCoroutine(DespawnFloor());
                isFloorDespawning = true;

                if(levelManager.playerLevel < level)
                {
                    int levelDiff = level - levelManager.playerLevel;
                    levelManager.playerLevel = level;

                    for(int i = 0; i < levelDiff; i++)
                    levelManager.OnPlayerFall.Invoke();
                }
            }
        }
    }

    private IEnumerator DespawnFloor()
    {
        bool isForward = true;
        float currentTime = 0f;
        Vector3 initialScale = gameObject.transform.localScale;
        Vector3 initialPosition = gameObject.transform.position;

        while(currentTime <= warningTime)
        {
            if (isForward)
            {
                if (gameObject.transform.position.x <= initialPosition.x + shakeDiff)
                {
                    transform.position += Vector3.right * Time.deltaTime * shakeSpeed;
                }
                else
                    isForward = false;
            }
            else
            {
                if (gameObject.transform.position.x >= initialPosition.x - shakeDiff)
                {
                    transform.position -= Vector3.right * Time.deltaTime * shakeSpeed;
                }
                else
                    isForward = true;
            }

            yield return null;
            currentTime += Time.deltaTime;
        }

        currentTime = 0f;

        while (currentTime <= dissapearTime)
        {
            gameObject.transform.localScale = Vector3.Slerp(initialScale, new Vector3(0, 0, 0), currentTime / dissapearTime);
            currentTime += Time.deltaTime;
            yield return null;
        }

        //yield return new WaitForSeconds(dissapearTime);

        Destroy(this.gameObject);
    }
}
