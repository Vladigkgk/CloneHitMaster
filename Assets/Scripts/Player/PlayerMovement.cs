using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Assers.Scripts.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform _wayPointsContainer;

        private PlayerController _player;
        private NavMeshAgent _playerNavMashAgent;
        private Transform[] _wayPoints;
        private int _currentCountWayPoint = 1;
        private bool _lastPoint;

        private void Start()
        {
            _player = GetComponent<PlayerController>();
            _playerNavMashAgent = GetComponent<NavMeshAgent>();
            _wayPoints = _wayPointsContainer.GetComponentsInChildren<Transform>();
        }

        private void Update()
        {
            if (_lastPoint && _playerNavMashAgent.remainingDistance < 0.5f)
                ReloadLevel();

            _player.SetAnimatorState(_playerNavMashAgent.remainingDistance > 0.5f);
        }

        [ContextMenu("GoToNextPosition")]
        public void GoToNextWayPoint()
        {
            _playerNavMashAgent.SetDestination(_wayPoints[_currentCountWayPoint].position);
            _currentCountWayPoint++;

            if (_currentCountWayPoint == _wayPoints.Length)
            {
                _lastPoint = true;
            }
        }

        private void ReloadLevel()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}

