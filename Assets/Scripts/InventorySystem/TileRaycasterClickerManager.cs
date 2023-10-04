using System.Collections.Generic;
using Handler;
using InputSystem;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{
    /// <summary>
    /// Fica ativado quando entrar no modo de uso de item (screen state)
    /// Habita na cena
    /// </summary>
    public class TileRaycasterClickerManager : MonoBehaviour
    {
        private InputManager _inputManager;
        private Vector2 mousePosition;
        [SerializeField] private LayerMask layerMask;
        public UnityEvent HandlerSuccessEvent;
        public UnityEvent HandlerFailEvent;
        private void Awake()
        {
            _inputManager = GameObject.FindFirstObjectByType<InputManager>();
        }

        private void OnEnable()
        {
            _inputManager.leftButtonChangedEvent.AddListener(OnLeftButtonChanged);
            _inputManager.mouseMovementEvent.AddListener(UpdateMousePosition);
        }
        private void OnDisable()
        {
            _inputManager.mouseMovementEvent.RemoveListener(UpdateMousePosition);
        }
        private void UpdateMousePosition(Vector2 arg0)
        {
            mousePosition = arg0;
        }
        /*
         * Escuta quando o mouse esquerdo é solto
         * Verifica se não tem nenhuma UI no caminho
         * Verifica se tem algum tile na posição do mouse
         * Chama o evento de click do tile
         */
        private void OnLeftButtonChanged(bool arg0)
        {
            if (arg0) return;
            var isMouseAboveUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            if (isMouseAboveUI) return;
            
            // Testar se o contact filter ta funcionando direito
            // Se não, boa sorte
            ContactFilter2D contactFilter2D = new ContactFilter2D();
            contactFilter2D.layerMask = layerMask;
            //contactFilter2D.SetLayerMask(layerMask);
                    
            List<RaycastHit2D> results = new List<RaycastHit2D>();
            Physics2D.Raycast(mousePosition, Vector2.zero, contactFilter2D, results);
            foreach (RaycastHit2D i in results)
            {
                GameObject target = i.collider.gameObject;
                TileHandler handler = target.GetComponent<TileHandler>();
                if (handler != null)
                {
                    HandlerFailEvent.Invoke();
                }
                else
                {
                    handler.tileClicker.Click();
                    HandlerSuccessEvent.Invoke();
                }
            }
        }
    }
}