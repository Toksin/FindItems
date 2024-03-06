using UnityEngine;

public class FillScreenWithColor : MonoBehaviour
{
    public Color fillColor = Color.blue;
    public float circleRadius = 2f;

    private void OnDrawGizmos()
    {       
        Gizmos.color = fillColor;
        Gizmos.DrawCube(Vector3.zero, new Vector3(Screen.width, Screen.height, 1));
        
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.clear;
        Gizmos.DrawSphere(cursorPosition, circleRadius);
    }

    private void Update()
    {       
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPosition.x, cursorPosition.y, 0);
    }
}
