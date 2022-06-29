using Assers.Scripts.Player;
using Assets.Scripts.Enemies;
using Assets.Scripts.Player.Weapon;
using Assets.Scripts.Pool;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GroupEnemy[] _groupEnemies;
        [SerializeField] private Transform _startBulletPositon;
        [SerializeField] private BulletsPool _pool;

        private PlayerMovement _playerMovement;
        private Animator _animator;

        private static int IsRunningKey = Animator.StringToHash("isRunning");


        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _animator = GetComponent<Animator>();

            foreach (var groupEnemy in _groupEnemies)
            {
                groupEnemy.AllEnemiesKill += OnAllEnemiesKilled;
            }
        }

        public void SetAnimatorState(bool value)
        {
            _animator.SetBool(IsRunningKey, value);
        }

        private void OnAllEnemiesKilled()
        {
            GoToNextPosition();
        }

        public void GoToNextPosition()
        {
            _playerMovement.GoToNextWayPoint();
        }

        public void Shot(Vector3 direction)
        {
            var bullet = _pool.GetBullet();
            if (bullet == null) return;
            bullet.transform.position = _startBulletPositon.position;
            bullet.SetPosition(direction);
            bullet.gameObject.SetActive(true);
        }

        private void Dispose()
        {
            foreach (var groupEnemy in _groupEnemies)
            {
                groupEnemy.AllEnemiesKill += OnAllEnemiesKilled;
            }
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}