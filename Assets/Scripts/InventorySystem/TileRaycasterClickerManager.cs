using System.Collections.Generic;
using Handler;
using InputSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

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
        private Camera cameraMain;
        private Vector2 _mousePosition;
        private int resultcount;
       
        

        private void Awake()
        {
            _inputManager = GameObject.FindFirstObjectByType<InputManager>();
            cameraMain = Camera.main;
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
            _mousePosition = arg0;
        }
        /*
         * Escuta quando o mouse esquerdo é solto
         * Verifica se não tem nenhuma UI no caminho
         * Verifica se tem algum tile na posição do mouse
         * Chama o evento de click do tile
         */
        private void OnLeftButtonChanged(bool arg0)
        {   Debug.Log("TileRaycasterClickerManager: OnLeftButtonChanged");
            if (arg0) return;
            var isMouseAboveUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            if (isMouseAboveUI) return;
            Debug.Log("TileRaycasterClickerManager: mouse is not above UI " );
            ContactFilter2D contactFilter2D = new ContactFilter2D();
            contactFilter2D.SetLayerMask(layerMask);
            List<RaycastHit2D> results = new List<RaycastHit2D>();
            Physics2D.Raycast(cameraMain.ScreenToWorldPoint(mousePosition),
                Vector2.zero, contactFilter2D, results);
            resultcount += results.Count;
            Debug.Log("Number of hits: " + results.Count);
            Debug.Log("Total number of hits: " + resultcount);
            
            foreach (RaycastHit2D i in results)
            {   
                GameObject target = i.collider.gameObject;
                TileHandler handler = target.GetComponentInChildren<TileHandler>();
                
                if (handler != null)
                {
                    Debug.Log("TileRaycasterClickerManager: TileHandler found");
                    if (handler.tileClicker != null)
                    {
                        handler.tileClicker.Click();
                    }
                    else
                    {
                        Debug.LogWarning("TileClicker not found on TileHandler");
                    }

                    HandlerSuccessEvent.Invoke();
                    Debug.Log("TileRaycasterClickerManager: TileHandler found");
                }
                else
                {
                    HandlerFailEvent.Invoke();
                    Debug.Log("TileRaycasterClickerManager: TileHandler not found");
                }
            }
        } 
    }
}
