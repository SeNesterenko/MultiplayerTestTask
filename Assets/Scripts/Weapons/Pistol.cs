using UnityEngine;

namespace Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private float _bulletVelocity = 20f;
        [SerializeField] private Transform _muzzle;

        public override void Shoot()
        {
            var bullet = _poolSystem.GetBullet();
            bullet.transform.position = _muzzle.transform.position;
            bullet.GetRigidBody().velocity = transform.right * _bulletVelocity;
        }
    }
}