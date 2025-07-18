using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int numberToEnter = 3;

    public void UpdateDoor()
    {
        numberToEnter--;

        if(numberToEnter <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
