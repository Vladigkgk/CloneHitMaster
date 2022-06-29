using System.Collections;
using UnityEngine;
using DG.Tweening;
using Assets.Scripts.Enemies;

namespace Assets.Scripts.Player.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private float _currentTime;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponentInParent<Enemy>();

            if (enemy != null)
            {
                enemy.ApplyDamage();
                gameObject.SetActive(false);

            }

            gameObject.SetActive(false);
        }

        public void SetPosition(Vector3 position)
        {
            _direction = position - transform.position;
        }

        private void FixedUpdate()
        {
            _rigidbody.position += _direction.normalized * _speed * Time.fixedDeltaTime;   
        }

        private void Update()
        {
            if (_currentTime > _lifeTime)
            {
                _currentTime = 0;
                gameObject.SetActive(false);
                return;
            }

            _currentTime += Time.deltaTime;
        }
    }
}