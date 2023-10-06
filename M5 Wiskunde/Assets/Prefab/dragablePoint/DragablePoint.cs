using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragablePoint : MonoBehaviour
{
    public bool dragging = false;

    private void Start()
    {
        
    }

    void Update()
    {
      Vector2 mousePostion = Input.mousePosition;
        if (dragging)
        {
            mousePostion = Camera.main.ScreenToWorldPoint(mousePostion);
            this.transform.position = mousePostion;
            Debug.Log(mousePostion);
        }
        
    }
    private void OnMouseDown()
    {
        dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
}
