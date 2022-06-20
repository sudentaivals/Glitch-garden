using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomShooter : BaseShooter
{
    [SerializeField] CustomFire _customFire;

    protected override void Shoot()
    {
        _customFire.SpawnProjectiles(_projectile, _gun);
    }

}
