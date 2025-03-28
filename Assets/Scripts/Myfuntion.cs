using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myfuntion : MonoBehaviour
{
    public static void ClearChild(Transform trans)
    {
        int count = trans.childCount;
        for (int i = count - 1; i >= 0; i--)
        {
            Transform child = trans.GetChild(i);
            child.gameObject.SetActive(false);
            DestroyImmediate(child.gameObject);
        }
    }
}
