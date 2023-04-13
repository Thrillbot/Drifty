using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsCustom : MonoBehaviour
{
	public GameObject[] partList;
    [System.Serializable]
    public struct Transforms
	{
		public Transform trans;
		public bool scale;
		public Vector3 initPos;
	}

	[System.Serializable]
	public struct Part
	{
		public GameObject part;
		public Transforms[] transforms;
	}

	public Part[] parts;

	private float moveVal;

	private void Awake()
	{
		FindNewBones();
	}

	public void FindNewBones()
	{
		for (int i = 0; i < parts.Length; i++)
		{
			if (parts[i].part.transform.childCount == 0)
				return;
			parts[i].transforms[0].trans = parts[i].part.transform.GetChild(0).GetChild(0);
            for (int j = 1; j < parts[i].transforms.Length; j++)
			{
                parts[i].transforms[j].trans = parts[i].part.GetComponent<Transform>().Find("Part/RootBone/" + j.ToString());
                parts[i].transforms[j].initPos = parts[i].transforms[j].trans.localPosition;
            }
		}
	}

	public void ChangePart(int partIndex)
	{
		for (int i = 0; i < parts.Length; i++)
		{
			GameObject oldPart = parts[i].part;
			if (partList[partIndex] != null)
			{
				parts[i].part = Instantiate(partList[partIndex]);
				parts[i].part.transform.parent = oldPart.transform.parent;
				parts[i].part.transform.position = oldPart.transform.position;
				parts[i].part.transform.eulerAngles = oldPart.transform.eulerAngles;
			}
			Destroy(oldPart);
		}
        FindNewBones();
    }

	public void MovePart (System.Single _moveVal)
	{
		moveVal = _moveVal;
	}	    
	public void boneSelect (int boneName)
	{
		MoveBone(boneName, moveVal);
	}	

	private void MoveBone (int bInd, float moveVal)
	{
		for (int i = 0; i < parts.Length; i++)
		{
			if  (parts[i].transforms[bInd].trans == null)
				return;
			if (parts[i].transforms[bInd].scale)
			{
                Vector3 w = parts[i].transforms[bInd].trans.localScale;
                parts[i].transforms[bInd].trans.localScale = new Vector3(w.x, moveVal,w.z);
			} 
			else
			{
                Vector3 t = parts[i].transforms[bInd].initPos;
                parts[i].transforms[bInd].trans.localPosition = new Vector3(t.x, t.y, t.z + moveVal * 0.01f);
            }
		}
	}
}
