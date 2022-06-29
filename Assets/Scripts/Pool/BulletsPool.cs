using Assets.Scripts.Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pool
{
    public class BulletsPool : MonoBehaviour
    {
        [SerializeField] private int _bulletsCount;
        [SerializeField] private Bullet _bullet;

        private List<Bullet> _bullets = new List<Bullet>();

        private void Start()
        {
            for (int i = 0; i < _bulletsCount; i++)
            {
                var bullet = Instantiate(_bullet, transform);
                _bullets.Add(bullet);
                bullet.gameObject.SetActive(false);
            }
        }

        public Bullet GetBullet()
        {
            foreach (var bullet in _bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    return bullet;
                }
            }
            return null;
        }
    }
}