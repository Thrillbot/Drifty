using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Parts;
using static PartsCustom;

public class Parts : MonoBehaviour
{
    public GameObject[] partList;
    public GameObject curPart;
    public void ChangePart(int partIndex)
    {
        GameObject oldPart = curPart;
        if (partList[partIndex] != null)
        {
            curPart = Instantiate(partList[partIndex]);
            curPart.transform.parent = oldPart.transform.parent;
            curPart.transform.position = oldPart.transform.position;
            curPart.transform.eulerAngles = oldPart.transform.eulerAngles;
        }
        Destroy(oldPart);
    }
}
