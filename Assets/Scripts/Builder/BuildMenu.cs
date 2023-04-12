using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
	private int rot = 120;

	public void RotateCar(int rotValue)
	{
		rot += rotValue;
	}

    void Update()
    {
    transform.localEulerAngles = Vector3.up * rot;
	}
}
