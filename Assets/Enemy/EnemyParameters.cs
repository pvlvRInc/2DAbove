using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyParameters", menuName = "Scriptable Object/EnemyParameters", order = 3)]
public class EnemyParameters : ScriptableObject
{
    public float cost;
    public float speed;
    public float aggressivness;
}
