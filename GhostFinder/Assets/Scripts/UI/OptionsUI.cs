using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    public event EventHandler BackButtonClicked;

    private const string CAMERA_BOOL_PARAMETR = "isActive";
    private const string OPTION_BOOL_PARAMETR = "Deactivate";

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button backButton;

    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private Animator cameraAnimation;
    [SerializeField] private Animator optionsCassetteAnimation;

    [SerializeField] private GameObject optionsUI;

    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        backButton.onClick.AddListener(() =>
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
            optionsCassetteAnimation.SetBool(OPTION_BOOL_PARAMETR, true);
            optionsUI.SetActive(false);
            cameraAnimation.SetBool(CAMERA_BOOL_PARAMETR, false);
        });
    }

    private void Start()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
    }
}
