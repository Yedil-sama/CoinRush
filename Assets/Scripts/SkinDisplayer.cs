using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject container;
    private int curSkinInd;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("SkinDefault") == 0)
        {
            PlayerPrefs.SetInt("SkinDefault", 1);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        SetupSlots();
    }
    private void SetupSlots()
    {
        
    }
}
