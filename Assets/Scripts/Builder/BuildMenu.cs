using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
	public GameObject[] wheels; 
	public GameObject[] fenders; 

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
