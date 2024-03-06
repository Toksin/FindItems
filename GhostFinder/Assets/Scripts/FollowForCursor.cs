using UnityEngine;

public class FollowForCursor : MonoBehaviour
{ 
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
