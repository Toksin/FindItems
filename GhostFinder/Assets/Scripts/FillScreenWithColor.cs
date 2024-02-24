using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScreenWithColor : MonoBehaviour
{
    public Color fillColor = Color.blue;
    public float circleRadius = 2f;

    private void OnDrawGizmos()
    {
        // Заполнение экрана цветом
        Gizmos.color = fillColor;
        Gizmos.DrawCube(Vector3.zero, new Vector3(Screen.width, Screen.height, 1));

        // Отображение кружочка в центре
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.clear;
        Gizmos.DrawSphere(cursorPosition, circleRadius);
    }

    private void Update()
    {
        // Движение кружочка за курсором
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPosition.x, cursorPosition.y, 0);
    }
}
