using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> body;

    [Space]
    [Header("Controllers")]
    [SerializeField] private InputX Input;
    [SerializeField] private Movement Movement;
    [SerializeField] private Rotation Rotation;
    [SerializeField] private CanvasDisplayer Displayer;
    [SerializeField] private SceneChanger SceneChanger;
    [SerializeField] private LevelProgress LevelProgress;

    //[Space]
    //[Header("Audio")]
    //[SerializeField] private AudioSource rollingAudio;
    //[SerializeField] private AudioSource hittingAudio;
    //[SerializeField] private AudioSource victoryAudio;
    //[SerializeField] private AudioSource defeatAudio;

    [Space]
    [Header("Others")]
    [SerializeField] private GameObject mainBody;
    [SerializeField] private GameObject bodyPrefab;
    [SerializeField] private ParticleSystem damageParticle;
    [SerializeField] private float immuneTime;
    [SerializeField] private SkinSO[] skins;
    private float nextVulnerableTime = 0f;
    private void Awake()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (PlayerPrefs.GetString("Skin") == skins[i].Name)
            {
                Destroy(mainBody);
                mainBody = Instantiate(skins[i].Model,transform);
                mainBody.transform.parent = transform;
                bodyPrefab = mainBody;
                
                
                for( int j = 0; j < body.Count; j++)
                {
                    body[j] = bodyPrefab;

                }
                break;
            }
        }

    }
    private void Update()
    {
        if (transform.rotation.y > 30f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 30, transform.position.z);
        }
        else if (transform.rotation.y < -30f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, -30, transform.position.z);
        }
        if (transform.rotation.z > 30f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 30);
        }
        else if (transform.rotation.z < -30f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -30);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RedZone")
        {
            if(Time.time >= nextVulnerableTime)
            {
                nextVulnerableTime = Time.time + immuneTime;
                if (body.Count > 1)
                {
                    Destroy(body[body.Count - 1].gameObject);
                    Destroy(other.gameObject);
                    body.RemoveAt(body.Count - 1);
                    LevelProgress.AddCurCoin(-1);
                    StartCoroutine(DamageTimer());
                    //StartCoroutine(Immune());
                }
                else
                {
                    GameOver();
                }
            }
            else
            {

            }
            
        }
        else if (other.tag == "DeadZone")
        {
            GameOver();
        }
        else if (other.tag == "VictoryZone")
        {
            StartCoroutine(VictoryTimer());
            LevelProgress.SaveProgress();
            LevelProgress.SaveCoins();
            other.enabled=false;

        }
        else if(other.tag == "Coin")
        {
            LevelProgress.AddCurCoin(1);
            GameObject newBody = Instantiate(bodyPrefab);
            newBody.transform.position = transform.position;
            newBody.transform.rotation = transform.rotation;
            newBody.transform.parent = gameObject.transform;

            body.Add(newBody);
            other.enabled=false;
            Destroy(other.gameObject);
        }
    }
    //private IEnumerator Immune()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        for (int j = 0; j < body.Count; j++) {
    //            Color curColor = body[j].GetComponent<Renderer>().material.color;
    //            curColor.a = 50;
    //            body[j].GetComponent<Renderer>().material.color = curColor;
    //        }
    //        yield return new WaitForSeconds(0.25f);
    //        for (int j = 0; j < body.Count; j++)
    //        {
    //            Color curColor = body[j].GetComponent<Renderer>().material.color;
    //            curColor.a = 255;
    //            body[j].GetComponent<Renderer>().material.color = curColor;
    //        }
    //    }
    //}
    private void GameOver()
    {
        Displayer.OpenGameCanvas(false);
        Displayer.OpenDeathCanvas(true);
        Destroy(Movement);
        Destroy(Rotation);
    }
    private IEnumerator DamageTimer()
    {
        damageParticle.Play();
        yield return new WaitForSeconds(1);
        damageParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
    private IEnumerator VictoryTimer()
    {
        Displayer.OpenWinCanvas(true);
        yield return new WaitForSeconds(1);
        SceneChanger.NextLevel();

    }
}