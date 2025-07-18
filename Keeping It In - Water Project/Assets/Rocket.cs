using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    public Level1CamaeraManager camaeraManager;
    public Level1Manager levelManager;

    private void Start()
    {
        levelManager.OnPlayerFall.AddListener(IncreaseSpeed);
    }

    private void Update()
    {
        if (!player)
            return;

        Vector3 lookAtGoal = player.transform.position;

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(player);
            camaeraManager.UpdateCameraLevel(camaeraManager.cameraPositions.Length);
        }
    }

    private void IncreaseSpeed()
    {
        speed++;
    }
}
