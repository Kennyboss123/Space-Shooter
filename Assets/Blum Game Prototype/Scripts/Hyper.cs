using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyper : Ball
{
    
    public override void UseSpecialSkills()
    {
        base.UseSpecialSkills();

        GameManagerTest.instance.hyperCountDown = 5f;

        GameManagerTest.instance.isPowerActive = true;

        GameManagerTest.instance.multiplier = _ballSO.powerValue;

       // base.TriggerExplosion();


    }
}
