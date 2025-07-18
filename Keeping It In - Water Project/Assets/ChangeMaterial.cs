using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private Door door;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<HeartPlayerControls>())
        {
            ChangeColorManager.instance.StartChange(newMaterial);
            Destroy(this.gameObject);

            if(door)
            door.UpdateDoor();
        }
    }
}
