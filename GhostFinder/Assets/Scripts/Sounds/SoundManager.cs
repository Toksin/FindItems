using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }   
    
    [SerializeField] private AudioClipsRefsSO audioClipsRefsSO;

    private float volume = 1f; 

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {      
        GameInput.Instance.OnEnvironmentMoved += GameInput_OnEnvironmentMoved;         
        ClickOnTargetSystem.Instance.OnClick += ClickOnTarget_OnClick;

        MainMenuManager mainMenuManager = MainMenuManager.Instance;
        if (mainMenuManager != null)
        {
            mainMenuManager.SoundActivate += MainMenuManager_CassetteAndDoorSoundActivate;
            mainMenuManager.SoundInsertCassette += mainMenuManager_SoundInsertCassette;
        }

        OptionsUI optionsUI = OptionsUI.Instance;
        if (optionsUI != null)
        {
            optionsUI.BackButtonClicked += BackButtonClicked_BackButtonClicked;
        }
    }



    private void BackButtonClicked_BackButtonClicked(object sender, System.EventArgs e)
    {
        StartCoroutine(PlayCasseteEject());
    }

    private void mainMenuManager_SoundInsertCassette(object sender, System.EventArgs e)
    {
        StartCoroutine(PlayCasseteInsert());
    }

    private void MainMenuManager_CassetteAndDoorSoundActivate(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsRefsSO.buttonÑlick, Camera.main.transform.position, 0.3f);    
    }

    private void ClickOnTarget_OnClick(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsRefsSO.win, Camera.main.transform.position);
    }

    private void GameInput_OnEnvironmentMoved(object sender, GameInput.OnEnvironmentMovedEventArgs e)
    {
        if (!Lvl0StartManager.Instance.IsCutsceneActive())
        {
            PlaySound(audioClipsRefsSO.rotateWorld, Camera.main.transform.position);
        }
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);      
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);        
    }

    public void ChangeVolume()
    {
        volume += 0.1f;
        if(volume > 1f)
        {
            volume = 0f;
        }      
    }

    public float GetVolume() { return volume; }

    private IEnumerator PlayCasseteInsert()
    {
        yield return new WaitForSeconds(2.5f);

        PlaySound(audioClipsRefsSO.tapeCassetteInsert, Camera.main.transform.position);
    }

    private IEnumerator PlayCasseteEject()
    {
        yield return new WaitForSeconds(1f);

        PlaySound(audioClipsRefsSO.tapeCassetteEject, Camera.main.transform.position, 0.3f);
    }
}
