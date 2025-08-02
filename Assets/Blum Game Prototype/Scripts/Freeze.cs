using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Ball
{
    public override void UseSpecialSkills()
    {
        base.UseSpecialSkills();

        GameManagerTest.instance.frozenCountdown = 3f;

        GameManagerTest.instance.isGameFrozen = true;

       // base.TriggerExplosion();

    }
}
