using System;
using UnityEngine;

[CreateAssetMenu]
public class BallSO: ScriptableObject
{
    public BallType ballType;
    public int powerValue;
    public GameObject ballVfx;
    public int freezeValue;
    public Color color;

    public int minValue, maxValue;
}