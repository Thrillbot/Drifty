using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenders : MonoBehaviour
{
	[System.Serializable]
	public struct Axle
	{
		public GameObject fender;
        public Transform size;
        public Transform fb;
        public Transform ft;
        public Transform rt;
        public Transform rb;
	}

	public Axle[] axle;

	public BuildMenu carRoot;

	private void Awake()
	{
		FindNewBones();
	}

    public void FindNewBones()
    {
        for (int i = 0; i < axle.Length; i++)
        {
            axle[i].size = axle[i].fender.GetComponent<Transform>().Find("Fender/FenderRoot");
            axle[i].fb = axle[i].fender.GetComponent<Transform>().Find("Fender/FenderRoot/FB");
            axle[i].ft = axle[i].fender.GetComponent<Transform>().Find("Fender/FenderRoot/FT");
            axle[i].rt = axle[i].fender.GetComponent<Transform>().Find("Fender/FenderRoot/RT");
            axle[i].rb = axle[i].fender.GetComponent<Transform>().Find("Fender/FenderRoot/RB");
        }
    }

    public void ChangeFender(int fenderIndex)
    {
		for (int i = 0; i < axle.Length; i++)
		{
			GameObject oldFender = axle[i].fender;
            axle[i].fender = Instantiate(carRoot.fenders[fenderIndex]);
            axle[i].fender.transform.parent = oldFender.transform.parent;
            axle[i].fender.transform.position = oldFender.transform.position;
            axle[i].fender.transform.eulerAngles = oldFender.transform.eulerAngles;
			Destroy(oldFender);
            FindNewBones();
        }
    }

    public void Resize (System.Single moveVal)
	{
		MoveBone("size", moveVal);
	}	    
	public void MoveFB (System.Single moveVal)
	{
		MoveBone("fb", moveVal);
	}	
	public void MoveFT (System.Single moveVal)
	{
		MoveBone("ft", moveVal);
	}	
	public void MoveRT (System.Single moveVal)
	{
		MoveBone("rt", moveVal);
	}	
	public void MoveRB (System.Single moveVal)
	{
		MoveBone("rb", moveVal);
	}

	private void MoveBone (string bName, float moveVal)
	{
		for (int i = 0; i < axle.Length; i++)
		{
			if (axle[i].size == null)
				return;

			switch (bName)
			{
                case "size":
                    Vector3 w = axle[i].size.transform.localScale;
                    axle[i].size.transform.localScale = new Vector3(w.x, moveVal, w.z);
                    break;
                case "ft":
					Vector3 tf = axle[i].ft.transform.localPosition;
                    axle[i].ft.transform.localPosition = new Vector3(tf.x, tf.y, moveVal);
					break;                
				case "fb":
					Vector3 bf = axle[i].fb.transform.localPosition;
                    axle[i].fb.transform.localPosition = new Vector3(bf.x,bf.y, moveVal * 0.01f);
					break;                
				case "rt":
					Vector3 tr = axle[i].rt.transform.localPosition;
                    axle[i].rt.transform.localPosition = new Vector3(tr.x,tr.y, moveVal);
					break;                
				case "rb":
					Vector3 br = axle[i].rb.transform.localPosition;
                    axle[i].rb.transform.localPosition = new Vector3(br.x,br.y, moveVal);
					break;


			}
		}
	}
}
