using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Create Level Data", order = 10)]
public class LevelData : ScriptableObject
{
    public int levelNumber;
    public float levelTime;
    public Level levelPrefab;
    public bool isSpawned;
}
