using System;
using System.Collections.Generic;
using Entities;
using Events;
using Photon.Pun;
using SimpleEventBus.Disposables;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

namespace Systems
{
    public class PoolSystem : MonoBehaviour, IDisposable
    {
        [SerializeField] private Bullet _bulletPrefab;
        
        private ObjectPool<Bullet> _pool;
        private Queue<Bullet> _bullets;
        private CompositeDisposable _subscriptions;

        private float _currentTime;

        public Bullet GetBullet()
        {
            return _pool.Get();
        }
        
        public void Dispose()
        {
            _pool?.Dispose();
            _subscriptions?.Dispose();
        }
        
        private void Awake()
        {
            _pool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool);
            _bullets = new Queue<Bullet>();
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<WeaponSpawnedEvent>(InitializePoolService)
            };
        }

        private void Update()
        {
            if (_bullets.Count != 0)
            {
                _currentTime += Time.deltaTime;   
            }

            if (_currentTime >= 1)
            {
                _currentTime = 0;
                var bullet = _bullets.Dequeue();
                _pool.Release(bullet);
            }
        }

        private void InitializePoolService(WeaponSpawnedEvent eventData)
        {
            eventData.Weapon.Initialize(this);
        }

        private void OnReturnBulletToPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnTakeBulletFromPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            _bullets.Enqueue(bullet);
        }

        private Bullet CreateBullet()
        {
            var obj = PhotonNetwork.Instantiate(_bulletPrefab.gameObject.name, transform.position, quaternion.identity);
            var bullet = obj.GetComponent<Bullet>();
            return bullet;
        }
    }
}