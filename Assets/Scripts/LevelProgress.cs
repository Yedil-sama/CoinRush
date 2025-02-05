using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelProgress : MonoBehaviour
{
    public int curLevel; 
    public int curCoins; // coins gained this level
    public int totalCoins; // total coins gained 
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private TMP_Text totalCoinsText;
    [SerializeField] private TMP_Text curCoinsText;
    [SerializeField] private TMP_Text levelNameText;
    [SerializeField] private TMP_Text curLevelText;
    [SerializeField] private TMP_Text nextLevelText;
    [SerializeField] private Image progressImage;

    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform finishPos;

    private float maxProgress;
    private float curDistance;
    private string saveProgressKey;
    private void Awake()
    {
        curCoins = 0;
        curLevel = SceneManager.GetActiveScene().buildIndex;
        totalCoins = PlayerPrefs.GetInt("Coins");
    }
    private void Start()
    {
        maxProgress=finishPos.position.z-playerPos.position.z;
        levelNameText.text = "Level " + curLevel;
        curCoinsText.text = curCoins + "";
        totalCoinsText.text = totalCoins + "";
        curLevelText.text = curLevel+"";
        nextLevelText.text = curLevel + 1 + "";

        saveProgressKey = "Level" + SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        curDistance = Mathf.InverseLerp(maxProgress, 0, finishPos.position.z - playerPos.position.z);
        progressImage.fillAmount = curDistance;
        SaveProgress();
    }
    public void AddCurCoin(int amount) {
        curCoins += amount;
        curCoinsText.text = curCoins + "";
    }
    public void SaveCoins()
    {
        if (curCoins > PlayerPrefs.GetInt(saveProgressKey+"Coins"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + (curCoins - PlayerPrefs.GetInt(saveProgressKey + "Coins")));
            PlayerPrefs.SetInt(saveProgressKey+"Coins", curCoins);
            PlayerPrefs.Save();
            totalCoinsText.text = PlayerPrefs.GetInt("Coins",0) + "";
        }
    }
    public void SaveProgress()
    {
        if (curDistance > PlayerPrefs.GetFloat(saveProgressKey+"Progress", 0f))
        {
            PlayerPrefs.SetFloat(saveProgressKey+"Progress", curDistance);
            PlayerPrefs.Save();
        }
        
    }
}
