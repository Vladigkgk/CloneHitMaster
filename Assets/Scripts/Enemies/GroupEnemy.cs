using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemies
{
    public class GroupEnemy : MonoBehaviour
    {
        private Enemy[] _enemies;

        public UnityAction AllEnemiesKill;

        private void Start()
        {
            _enemies = GetComponentsInChildren<Enemy>();

            foreach(var enemy in _enemies)
            {
                enemy.Kill += OnKill;
            }
        }

        private void OnKill()
        {
            foreach(var enemy in _enemies)
            {
                if (!enemy.IsKilled)
                    return;
            }

            AllEnemiesKill?.Invoke();
            Dispose();
        }

        private void Dispose()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Kill -= OnKill;
            }
        }
    }
}