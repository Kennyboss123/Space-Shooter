using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ball
{
    public AudioSource tappingSFX;
    public override void UseSpecialSkills()
    {
        base.UseSpecialSkills();
        GameEvents.instance.OnScoreChanged?.Invoke(_ballSO.powerValue);

       // base.TriggerExplosion();
    }
}