using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openbook : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;

    public void Openpanel()
    {
        if (Panel1 != null)
        {
            bool isActive = Panel1.activeSelf;
            Panel1.SetActive(!isActive);
            Panel2.SetActive(isActive);
        }
    }
}