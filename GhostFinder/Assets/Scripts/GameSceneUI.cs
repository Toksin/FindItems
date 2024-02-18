using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Loader.Load(Loader.Scene.MainMenu);
        }
    }
}
