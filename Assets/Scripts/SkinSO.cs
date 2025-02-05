using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkinData", menuName = "CoinRunner/New Skin Data")]
public class SkinSO : ScriptableObject
{
    public string Name;
    public int Cost;
    public GameObject Model;
    public Sprite Sprite;
}
