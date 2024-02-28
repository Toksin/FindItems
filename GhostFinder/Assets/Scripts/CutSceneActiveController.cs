using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneActiveController : MonoBehaviour
{
    public static CutSceneActiveController Instance { get; private set; }
    private Lvl0StartManager lvl0StartManager;
    private Lvl1StartManager lvl1StartManager;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        lvl0StartManager = GetComponent<Lvl0StartManager>();
        lvl1StartManager = GetComponent<Lvl1StartManager>();
    }

    public bool IsCutsceneActive()
    {
        if (lvl0StartManager != null)
        {
            return lvl0StartManager.IsCutsceneActive();
        }
        else if (lvl1StartManager != null)
        {
            return false;
        }
        return false;
    }
}
