using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenVideoActivator : MonoBehaviour
{
    [SerializeField] private MainMenuManager mainMenuManager;
    [SerializeField] private GameObject videoScreen;
    void Start()
    {
        OptionsUI.Instance.BackButtonClicked += OptionUI_BackButtonClicked;
        mainMenuManager.NewGameCassetteActivate += MainMenuManager_NewGameCassetteActivate;
        mainMenuManager.LoadCassetteActivate += MainMenuManager_LoadCassetteActivate;
        mainMenuManager.OptionCassetteActivate += MainMenuManager_OptionCassetteActivate;     
    }  

    private void OptionUI_BackButtonClicked(object sender, System.EventArgs e)
    {
        StartCoroutine(EndVideoCorutine());
    }

    private void MainMenuManager_OptionCassetteActivate(object sender, System.EventArgs e)
    {
        StartCoroutine(StartVideoCorutine());
    }

    private void MainMenuManager_LoadCassetteActivate(object sender, System.EventArgs e)
    {
        StartCoroutine(StartVideoCorutine());
    }

    private void MainMenuManager_NewGameCassetteActivate(object sender, System.EventArgs e)
    {
        StartCoroutine(StartVideoCorutine());
    }

   private IEnumerator StartVideoCorutine()
   {
        yield return new WaitForSeconds(3f);

        videoScreen.SetActive(true);
   }

    private IEnumerator EndVideoCorutine()
    {
        yield return new WaitForSeconds(1f);

        videoScreen.SetActive(false);
    }
}
