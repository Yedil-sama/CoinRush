using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDisplayer : MonoBehaviour
{
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas deathCanvas;

    //[Space]
    //[Header("Sound")]
    //[SerializeField] private AudioClip buttonSource;

    [Space]
    [Header("GameCanvas")]
    [SerializeField] private Button startLevelButton;

    [Space]
    [Header("SettingsCanvas")]
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Color turnOnColor;
    [SerializeField] private Color turnOffColor;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        musicButton.image.color = turnOnColor;
        soundButton.image.color = turnOnColor;
        settingsCanvas.enabled = false;
        gameCanvas.enabled = true;
        winCanvas.enabled = false;
        deathCanvas.enabled = false;

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            PressMusicButton();
        }
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PressSoundButton();
        }
        Time.timeScale = 0f;
    }
    public void OpenSettingsCanvas(bool action)
    {
        if (action)
        {
            Time.timeScale = 0f;
            settingsCanvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            settingsCanvas.enabled = false;
        }
    }
    public void OpenGameCanvas(bool action)
    {
        gameCanvas.enabled = action;
    }
    public void OpenWinCanvas(bool action)
    {
        winCanvas.enabled = action;
    }
    public void OpenDeathCanvas(bool action)
    {
        deathCanvas.enabled = action;
    }
    public void PressMusicButton()
    {
        if (musicButton.image.color == turnOnColor)
        {
            musicButton.image.color = turnOffColor;
            Camera.main.GetComponent<AudioSource>().Stop();
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            musicButton.image.color= turnOnColor;
            Camera.main.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("Music", 1);
        }
        PlayerPrefs.Save();
    }
    public void PressSoundButton()
    {
        if (soundButton.image.color == turnOnColor)
        {
            soundButton.image.color = turnOffColor;
            player.GetComponent<AudioSource>().volume = 0f;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            soundButton.image.color = turnOnColor;
            player.GetComponent<AudioSource>().volume = 0.2f;
            PlayerPrefs.SetInt("Sound", 1);

        }
        PlayerPrefs.Save();
    }
    public void StartLevel()
    {
        Time.timeScale = 1f;
        startLevelButton.gameObject.SetActive(false);

        settingsCanvas.enabled = false;
        gameCanvas.enabled = true;
        winCanvas.enabled = false;
        deathCanvas.enabled = false;

    }
}
