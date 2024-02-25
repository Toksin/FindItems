using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{    
    [SerializeField] private MainMenuManager mainMenuManager;
    [SerializeField] private WinScreenUI winScreenUI;

    private int levelID = 0;

    private void Awake()
    {
        SaveSystem.Init();      
      
    }

    private void Start()
    {
        if (mainMenuManager != null)
        {
            mainMenuManager.NewGameCassetteActivate += MainMenuManager_NewGameCassetteActivate;
            mainMenuManager.LoadCassetteActivate += MainMenuManager_LoadCassetteActivate;
        }

        if (winScreenUI != null)
        {
            winScreenUI.OnNextLLevelButtonClicked += WinScreenUI_OnNextLLevelButtonClicked;
        }      
    }  

    private void WinScreenUI_OnNextLLevelButtonClicked(object sender, System.EventArgs e)
    {
        NextLevel();
        StartCoroutine(LoadAfterDelay());
    }

    private void MainMenuManager_LoadCassetteActivate(object sender, System.EventArgs e)
    {        
        StartCoroutine(LoadAfterDelay());
    }

    private void MainMenuManager_NewGameCassetteActivate(object sender, System.EventArgs e)
    {
        ResetGame();
        StartCoroutine(LoadAfterDelay());
    }
     
    private void ResetGame()
    {
         levelID = 0;

        SaveObject saveObject = new SaveObject
        {
            LevelID = levelID,
        };

        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.Save(json);        
    }

    private void NextLevel()
    {
        levelID++;

        SaveObject saveObject = new SaveObject
        {
            LevelID = levelID,
        };

        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.Save(json);
    }

    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        Load();
    }
    
    private void Load()
    {
        string saveString = SaveSystem.Load();
        
        if(saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            int loadedLevelID = saveObject.LevelID;

            Loader.Load(loadedLevelID);
        }
        else
        {
            Debug.Log("No saved data found.");
        }
    }
    

    private class SaveObject
    {
        public int LevelID;
    }
}
