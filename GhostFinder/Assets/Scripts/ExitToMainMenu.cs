using UnityEngine;
using UnityEngine.UI;

public class ExitToMainMenu : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(0);
        });
    }
}
