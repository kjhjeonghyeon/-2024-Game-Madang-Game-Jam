using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOption", menuName = "Scriptable Objects/EnemyOption")]
public class EnemyOption : ScriptableObject
{
    public float minSpawnDelay;
    public float maxSpawnDelay;
}
