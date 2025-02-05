using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    [Header("Data")]
    public SkinSO skin;

    [Space]
    [Header("UI")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image iconImage;

    [SerializeField] private Image lockImage;
    [SerializeField] private Image lockBackground;
    
    private bool isAvailable = false;
    private void Start()
    {
        if(PlayerPrefs.GetInt(skin.Name+"Skin") == 1 || skin.Name == "Default")
        {
            lockImage.enabled = false;
            lockBackground.enabled = false;
            isAvailable = true;
        }
        else
        {
            lockImage.enabled = true;
            lockBackground.enabled = true;
            isAvailable = false;
        }
        nameText.text = skin.Name;
        costText.text = skin.Cost+"$";
        iconImage.sprite = skin.Sprite;
    }
    public void BuySkin()
    {
        if (PlayerPrefs.GetInt("Coins") >= skin.Cost)
        {
            PlayerPrefs.SetInt(skin.Name + "Skin", 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - skin.Cost);
            PlayerPrefs.Save();
            lockImage.enabled = false;
            lockBackground.enabled = false;
            isAvailable = true;
        }
    }
    public void SelectSkin()
    {
        if (isAvailable)
        {
            PlayerPrefs.SetString("Skin", skin.Name);
            PlayerPrefs.Save();
        }
        else
        {
            BuySkin();
        }
    }
}
