using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
	public Transform spokes;
	public Transform dish;
	public Transform size;

	private void Awake()
	{
		spokes = GetComponent<Transform>().Find("Wheel/WheelRoot/SpokeOffset");
		dish = GetComponent<Transform>().Find("Wheel/WheelRoot/SpokeOffset/DishOffset");
        size = GetComponent<Transform>().Find("Wheel/WheelRoot");
	}

	public void MoveSpokes (System.Single moveVal)
	{
		MoveBone("spokes", moveVal);
	}	
	public void MoveDish (System.Single moveVal)
	{
		MoveBone("dish", moveVal);
	}	
	public void MoveSize (System.Single moveVal)
	{
		MoveBone("size", moveVal);
	}	
	public void MoveWidth (System.Single moveVal)
	{
		MoveBone("width", moveVal);
	}

	private void MoveBone (string bName, float moveVal)
	{
		switch (bName)
		{
			case "spokes":
				Vector3 sp = spokes.transform.localPosition;
                spokes.transform.localPosition = new Vector3(sp.x, moveVal * 0.001f, sp.z);
			break;
			case "dish":
                Vector3 dp = dish.transform.localPosition;
                dish.transform.localPosition = new Vector3(dp.x,moveVal * 0.001f, dp.z);
			break;			
			case "size":
                Vector3 s = size.transform.localScale;
                size.transform.localScale = new Vector3(moveVal,s.y,moveVal);
			break;			
			case "width":
                Vector3 w = size.transform.localScale;
                size.transform.localScale = new Vector3(w.x,moveVal, w.z);
			break;
		}
	}
}
