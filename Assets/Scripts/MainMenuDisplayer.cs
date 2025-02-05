using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuDisplayer : MonoBehaviour
{
    [SerializeField] private SceneChanger SceneChanger;
    [SerializeField] private LevelDisplayer LevelDisplayer;

    [SerializeField] private Canvas levelChooseCanvas;
    [SerializeField] private Canvas skinCanvas;
    [SerializeField] private Canvas mainMenuCanvas;

    [SerializeField] private TMP_Text totalCoinsText;
    [SerializeField] private Image totalCoinsImage;
    private void Start()
    {
        mainMenuCanvas.enabled = true;
        levelChooseCanvas.enabled = false;
        skinCanvas.enabled = false;
        

    }
    private void Update()
    {
        totalCoinsText.text = PlayerPrefs.GetInt("Coins") + "";
    }
    public void OpenLevelChooseCanvas(bool action)
    {
        if (action)
        {
            levelChooseCanvas.enabled = true;
            mainMenuCanvas.enabled = false;
            skinCanvas.enabled = false;
            totalCoinsImage.enabled = false;
        }
        else {
            levelChooseCanvas.enabled = false;
            mainMenuCanvas.enabled = true;
            skinCanvas.enabled = false;
            totalCoinsImage.enabled = true;
        }
    }
    public void OpenSkinCanvas(bool action)
    {
        if (action)
        {
            skinCanvas.enabled = true;
            mainMenuCanvas.enabled = false;
            levelChooseCanvas.enabled =false;
        }
        else
        {
            skinCanvas.enabled = false;
            mainMenuCanvas.enabled = true;
            levelChooseCanvas.enabled = false;
        }
    }
    public void PressHideButton()
    {
        if (mainMenuCanvas.enabled)
        {
            mainMenuCanvas.enabled = false;
            totalCoinsImage.enabled =false;
            totalCoinsText.enabled = false;
            levelChooseCanvas.enabled = false;
        }
        else
        {
            mainMenuCanvas.enabled = true;
            totalCoinsImage.enabled = true;
            totalCoinsText.enabled = true;
            levelChooseCanvas.enabled = false;
        }
    }
    
    public void PressPlay()
    {
        LevelDisplayer.StartLevel();
    }
}
