using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular: Ball
{
    public override void UseSpecialSkills()
    {
        base.UseSpecialSkills();
        GameEvents.instance.OnScoreChanged?.Invoke(_ballSO.powerValue);
        //base.TriggerExplosion();
    }
}
