using System.Collections.Generic;
using Database.Contents;
using Database.Interpreters;
using Database.UI.ActionPopup;
using Database.UI.InfoPopup;
using Unity.Collections;
using UnityEngine;

namespace Database.ItemCategories
{
    public class SeedInjector : CategoryInjector
    {
        [SerializeField] private GameObject _actionpopupPrefab;
        [SerializeField] private GameObject _infopopupPrefab;
        
        [SerializeField] private ActionPopupSpawner _actionPopupSpawner;
        [SerializeField] private InfoPopupSpawner _infoPopupSpawner;
        
        [SerializeField] private ActionPopupController _actionPopupController;
        [SerializeField] private InfoPopupController _infoPopupController;
        [ReadOnly][SerializeField] GameObject PopupInstance;
        
        // [SerializeField] private List<GameObject> seedspopupPrefabs = new List<GameObject>();

        public override void Inject(string itemName)
        {
            var seed = DatabaseSingleton.Instance.seedInterpreter.GetSeed(itemName);
            var item = DatabaseSingleton.Instance.itemInterpreter.GetItem(itemName);
            if (item == null)
            {
                Debug.LogError("Item not found");
                return;
            }
            if (seed == null)
            {
                Debug.LogError("Seed not found");
                return;
            }

            _actionPopupController.openPopupEvent.AddListener(OnOpenPopup);
            _actionPopupController.closePopupEvent.AddListener(OnClosePopup);
            _infoPopupController.openPopupEvent.AddListener(OnOpenPopup);
            _infoPopupController.closePopupEvent.AddListener(OnClosePopup);


            PopupInstance = _actionPopupSpawner.Spawn(_actionpopupPrefab);
            PopupInstance.GetComponent<SeedActionPopup>().Inject(item, seed);
            
            
        }

        private void OnOpenPopup()
        {
            PopupInstance.SetActive(true);
            Debug.Log("Popup opened");
        }
        private void OnClosePopup()
        {
            PopupInstance.SetActive(false);
            Debug.Log("Popup closed");
        }
    }

  
}