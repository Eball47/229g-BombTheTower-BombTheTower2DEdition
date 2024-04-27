using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture; // Your custom cursor sprite
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
    
    void Update()
    {
        Cursor.visible = true; 
        Vector2 cursorPos = Input.mousePosition;
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
    
}
