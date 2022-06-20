using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "Custom fire mode")]
public class CustomFire : ScriptableObject
{
    [SerializeField] int _numberOfProjectiles = 1;
    [SerializeField] List<Vector2> _directions;

    public void SpawnProjectiles(GameObject projectilePrefab, Transform gun)
    {
        if (_directions.Count != _numberOfProjectiles) throw new UnityException("Number of projectiles and directions dont match");
        for (int i = 0; i < _numberOfProjectiles; i++)
        {
            var projectile = Instantiate(projectilePrefab, gun.position, Quaternion.identity);
            projectile.GetComponent<Movement>().ChangeDirection(_directions[i]);
        }
    }
}
