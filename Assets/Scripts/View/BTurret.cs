using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.User;


namespace VUD_Project.View
{
    public class BTurret : Turret
    {

        private void Start()
        {
            ArrangeEnumValues();

        }

        private void Update()
        {
            ReArrangeEnemyList();
            ReDirectClosestEnemy();
            ControlShootConditions();
        }
    }
}

