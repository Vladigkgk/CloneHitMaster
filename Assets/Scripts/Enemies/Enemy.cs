using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private float _force;
        [SerializeField] private Rigidbody _rigidbodyRoot;
        [SerializeField] private Material _killedMaterial;

        private Animator _animator;

        public bool IsKilled { get; private set; }
        public int MaxHealth => _health;

        public UnityAction Kill;
        public UnityAction<int> HealthChanged;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void ApplyDamage()
        {
            _health--;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
                KillEnemy();
        }

        private void KillEnemy()
        {
            IsKilled = true;
            Kill?.Invoke();

            SkinnedMeshRenderer mesh = GetComponentInChildren<SkinnedMeshRenderer>();
            mesh.material = _killedMaterial;
            _animator.enabled = false;
            _rigidbodyRoot.AddForce(Vector3.forward * _force, ForceMode.Force);
        }

    }
}