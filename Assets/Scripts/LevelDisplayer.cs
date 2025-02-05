using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Image progressImage;
    [SerializeField] private Image lockBackgroundImage;
    [SerializeField] private Image lockImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image previewImage;
    [SerializeField] private SceneChanger SceneChanger;
    [SerializeField] private LevelSO[] levels;
    
    private int curLevelInd;
    private void Start()
    {
        lockBackgroundImage.enabled = false;
        lockImage.enabled = false;
        curLevelInd = PlayerPrefs.GetInt("Level", 1) - 1;
        if (curLevelInd < 1)
        {
            PlayerPrefs.SetInt("Level", 1);
            curLevelInd = 0;
        }
        FillDiscription();
    }
    public void StartLevel()
    {
        if (PlayerPrefs.GetInt("Level") > curLevelInd)
        {
            SceneChanger.ChangeScene(levels[curLevelInd].SceneInd);
        }
    }
    public void ChangeLevel(int ind)
    {
        curLevelInd = ind;
        FillDiscription();
    }
    public void NextLevel()
    {
        if (curLevelInd + 1 >= levels.Length) return;
        ChangeLevel(curLevelInd + 1);
    }
    public void PrevLevel()
    {
        if (curLevelInd - 1 < 0) return;
        ChangeLevel(curLevelInd - 1);
    }
    private void FillDiscription()
    {
        if (curLevelInd < PlayerPrefs.GetInt("Level"))
        {
            lockBackgroundImage.enabled = false;
            lockImage.enabled = false;
        }
        else { 
            lockBackgroundImage.enabled = true;
            lockImage.enabled = true;
        }
        levelName.text = levels[curLevelInd].Name;
        backgroundImage.sprite = levels[curLevelInd].LevelBackground;
        previewImage.sprite = levels[curLevelInd].Preview;
        float progress = PlayerPrefs.GetFloat("Level" + levels[curLevelInd].SceneInd + "Progress");
        coinsText.text = PlayerPrefs.GetInt("Level" + levels[curLevelInd].SceneInd + "Coins")+"/3";
        progressText.text = (progress * 100).ToString("0") + "%";
        progressImage.fillAmount = progress;

    }

}
