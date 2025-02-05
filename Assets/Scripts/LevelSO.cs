using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "CoinRunner/New Level Data")]
public class LevelSO : ScriptableObject
{
    public string Name;
    public int SceneInd;
    public Sprite Preview;
    public Sprite LevelBackground;
}
