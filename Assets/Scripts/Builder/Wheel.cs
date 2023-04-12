using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public GameObject[] wheelList;

    [System.Serializable]
	public struct Axle
	{
		public GameObject wheel;
        public Transform spokes;
        public Transform dish;
        public Transform size;
	}

	public Axle[] axle;

	private void Awake()
	{
		FindNewWheelBones();
	}

    public void FindNewWheelBones()
    {
        for (int i = 0; i < axle.Length; i++)
        {
            axle[i].spokes = axle[i].wheel.GetComponent<Transform>().Find("Wheel/WheelRoot/SpokeOffset");
            axle[i].dish = axle[i].wheel.GetComponent<Transform>().Find("Wheel/WheelRoot/SpokeOffset/DishOffset");
            axle[i].size = axle[i].wheel.GetComponent<Transform>().Find("Wheel/WheelRoot");
        }
    }

    public void ChangeWheel(int wheelIndex)
    {
		for (int i = 0; i < axle.Length; i++)
		{
			GameObject oldWheel = axle[i].wheel;
            axle[i].wheel = Instantiate(wheelList[wheelIndex]);
            axle[i].wheel.transform.parent = oldWheel.transform.parent;
            axle[i].wheel.transform.position = oldWheel.transform.position;
            axle[i].wheel.transform.eulerAngles = oldWheel.transform.eulerAngles;
			Destroy(oldWheel);
            FindNewWheelBones();
        }
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
		for (int i = 0; i < axle.Length; i++)
		{
			if (axle[i].spokes == null)
				return;

			switch (bName)
			{
				case "spokes":
					Vector3 sp = axle[i].spokes.transform.localPosition;
                    axle[i].spokes.transform.localPosition = new Vector3(sp.x, moveVal * 0.001f, sp.z);
					break;
				case "dish":
					Vector3 dp = axle[i].dish.transform.localPosition;
                    axle[i].dish.transform.localPosition = new Vector3(dp.x, moveVal * 0.001f, dp.z);
					break;
				case "size":
					Vector3 s = axle[i].size.transform.localScale;
                    axle[i].size.transform.localScale = new Vector3(moveVal, s.y, moveVal);
					break;
				case "width":
					Vector3 w = axle[i].size.transform.localScale;
                    axle[i].size.transform.localScale = new Vector3(w.x, moveVal, w.z);
					break;
			}
		}
	}
}
