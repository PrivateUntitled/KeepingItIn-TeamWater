using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPlayerControls : CharacterControls
{
	protected override void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 v2 = -v * Vector3.forward; //Vertical axis to which I want to move with respect to the camera
		Vector3 h2 = -h * Vector3.right; //Horizontal axis to which I want to move with respect to the camera
		moveDir = (v2 + h2).normalized; //Global position to which I want to move in magnitude 1

		anim.SetBool("IsWalking", h != 0 || v != 0);

		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f))
		{
			if (hit.transform.tag == "Slide")
			{
				slide = true;
			}
			else
			{
				slide = false;
			}
		}
	}
}
