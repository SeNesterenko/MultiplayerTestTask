using UnityEngine;

namespace Entities
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D GetRigidBody()
        {
            return _rigidbody;
        }

        public int GetDamageValue()
        {
            return _damage;
        }
    }
}