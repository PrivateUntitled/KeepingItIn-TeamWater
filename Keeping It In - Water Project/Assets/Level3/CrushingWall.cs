using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushingWall : MonoBehaviour
{
    public int speed;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CharacterControls>())
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
