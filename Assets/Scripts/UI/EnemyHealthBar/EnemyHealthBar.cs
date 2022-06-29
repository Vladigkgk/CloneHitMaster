using Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.EnemyHealthBar
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        private int _maxHealth;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponentInParent<Enemy>();

            _maxHealth = _enemy.MaxHealth;

            _enemy.Kill += OnKill;
            _enemy.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int currentHealth)
        {
            float amount = (float)currentHealth / _maxHealth;
            _healthBar.fillAmount = amount;
        }

        private void OnKill()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _enemy.Kill -= OnKill;
            _enemy.HealthChanged -= OnHealthChanged;
        }
    }
}