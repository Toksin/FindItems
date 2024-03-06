using System.Collections;
using UnityEngine;

public class OptionSystem : MonoBehaviour
{  
    private const string CAMERA_BOOL = "isActive";
    public static OptionSystem Instance { get; private set; }

    [SerializeField] private GameObject optionUI;
    [SerializeField] private Animator cameraAnimation;

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        MainMenuManager.Instance.OptionCassetteActivate += MainMenuManager_OptionCassetteActivate;
    }

    private void MainMenuManager_OptionCassetteActivate(object sender, System.EventArgs e)
    {
        StartCoroutine(ActivateCameraAnim());
        StartCoroutine(LoadOptionScreen());
    }

    private IEnumerator LoadOptionScreen()
    {
        yield return new WaitForSeconds(4f);

        optionUI.SetActive(true);
    }

    private IEnumerator ActivateCameraAnim()
    {
        yield return new WaitForSeconds(3f);

        cameraAnimation.SetBool(CAMERA_BOOL, true);
    }
}
