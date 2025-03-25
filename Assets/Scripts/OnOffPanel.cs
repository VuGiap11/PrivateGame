using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Private
{
    public class OnOffPanel : MonoBehaviour
    {
        public GameObject ObjPanel;
        public void OnOff()
        {
            ObjPanel.SetActive(!ObjPanel.activeSelf);
        }
    }
}

