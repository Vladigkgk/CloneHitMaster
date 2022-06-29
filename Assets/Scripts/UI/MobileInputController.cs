using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class MobileInputController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private GameObject _text;
        [SerializeField] private Vector3 _offsetPos;
        [SerializeField] private float _distance;

        private PlayerController _player;
        private Ray _ray;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_text.activeSelf)
            {
                _player.GoToNextPosition();
                HideText();
                return;
            }

            _ray = Camera.main.ScreenPointToRay(eventData.position);
            _player.Shot(_ray.GetPoint(_distance));
        }
       
        private void HideText()
        {
            _text.SetActive(false);
        }
    }
}