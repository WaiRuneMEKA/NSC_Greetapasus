using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 warpPosition;

    //void Start()
    //{
    //    warpPosition = transform.position;
    //}

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        warpPosition = transform.position;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    void OnMouseUp()
    {
        transform.position = warpPosition;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlaceCard")
        {
            warpPosition = col.gameObject.transform.position;
        }
    }
}