using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
   
    public enum CursorType
    {
        DefaultCursor,
        ZoomCursor
    }
    void Start()
    {
       Cursor.SetCursor(cursorTexture, new Vector2(10, 10), CursorMode.Auto);
    }   
}
