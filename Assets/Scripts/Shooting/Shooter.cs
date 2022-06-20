using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : BaseShooter
{
    protected override void Shoot()
    {
        Instantiate(_projectile, _gun.position, transform.rotation);
    }

}
