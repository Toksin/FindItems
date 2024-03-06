using UnityEngine;

public class Lvl0StartManager : MonoBehaviour
{
    public static Lvl0StartManager Instance { get; private set; }

    [SerializeField] private GameObject cursorZoom;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject pickUpGameObject;    
    [SerializeField] private GameObject AssistantUIGameObject;  

    [SerializeField] private ClickOnTargetSystem clickOnTargetSystem;

    [SerializeField] private Animator pickUpGameObjectAnimator;
    private bool isCutsceneActive = false;
    private const string ACTIVATE_ANIM_BOOL = "isShowing";
    private const string PICK_UP_GAMEOBJECT_TAG = "Target";

    private void Awake()
    {
        Instance = this;
        clickOnTargetSystem.OnClick += ClickOnTargetSystem_OnClick;        
    }

    private void ClickOnTargetSystem_OnClick(object sender, System.EventArgs e)
    {       
        cursorZoom.SetActive(false);
        cursor.SetActive(true);
        AssistantUIGameObject.SetActive(false);
        pickUpGameObject.SetActive(false);
    }

    private void Start()
    {
        isCutsceneActive = true;
        cursorZoom.SetActive(true);
        cursor.SetActive(false);
    }
    private void Update()
    {
        HideAssistant();
        ActivatePickUpGameObjectAnimation();
        SetPickUpGameObjectTriggered();
        IsCutsceneActive();      
    }

    public bool IsCutsceneActive()
    {
        if (AssistantUI.Instance.GetCurrentMessageIndex() > 5)
        {
            return isCutsceneActive = false;
        }
        return isCutsceneActive;
    }

    private void HideAssistant()
    {
        if(AssistantUI.Instance.GetCurrentMessageIndex() > 5)
        {
            AssistantUIGameObject.SetActive(false);
        }
    } 

    private void SetPickUpGameObjectTriggered()
    {
       if(AssistantUI.Instance.GetCurrentMessageIndex() > 5)
       pickUpGameObject.tag = PICK_UP_GAMEOBJECT_TAG;
    }

    private void ActivatePickUpGameObjectAnimation()
    {
        if (AssistantUI.Instance.GetCurrentMessageIndex() == 4)
        {
            pickUpGameObjectAnimator.SetBool(ACTIVATE_ANIM_BOOL, true);
        }
    }
}
