using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class MobileInputController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private GameObject _text;

        private PlayerController _player;

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

            Ray ray = Camera.main.ScreenPointToRay(eventData.position);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                _player.Shot(hit.point);
            }
        }
       
        private void HideText()
        {
            _text.SetActive(false);
        }
    }
}