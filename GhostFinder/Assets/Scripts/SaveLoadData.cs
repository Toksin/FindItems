using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    private void Awake()
    {
        SaveSystem.Init();       
      
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        int levelID = 0;

        SaveObject saveObject = new SaveObject
        {
            LevelID = levelID,
        };

        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.Save(json);
        Debug.Log("Saved!");
    }

    private void Load()
    {
        string saveString = SaveSystem.Load();
        if(saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            // SetLevel(saveObject.LevelID);
        }
    }
    

    private class SaveObject
    {
        public int LevelID;
    }
}
