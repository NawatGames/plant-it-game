using System;
using Handler;
using Tile;
using Tile.NutrientSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Plant.NutrientSystem
{
    [Serializable]
    class NutrientRelation
    {
        public NutrientLocator.NutrientKey nutrientKey;
        public float minAmount;
        [HideInInspector] public TileNutrient nutrientReference;
    }
    public class PlantNutrientHandler : MonoBehaviour
    {
        [SerializeField] private NutrientRelation[] nutrients;
        [SerializeField] private TileReference _tileReference;
        public UnityEvent<bool> neededNutrientsChangedEvent;
        private NutrientLocator _nutrientLocator;
        private bool _hasNeededNutrients = false;
        
        public bool HasNeededNutrients()
        {
            return _hasNeededNutrients;
        }

        private void OnEnable()
        {
            _tileReference.handlerUpdateEvent.AddListener(OnHandlerUpdated);
        }
        private void OnDisable()
        {
            _tileReference.handlerUpdateEvent.RemoveListener(OnHandlerUpdated);
            foreach (NutrientRelation nutrientRelation in nutrients)
            {
                if (nutrientRelation.nutrientReference != null)
                {
                    nutrientRelation.nutrientReference.amountChangedEvent.RemoveListener(Refresh);
                }
            }
        }

        void OnHandlerUpdated(TileHandler handler)
        {
            // Guarantees that the event is not subscribed twice
            if (_nutrientLocator != null)
            {
                foreach (NutrientRelation nutrientRelation in nutrients)
                {
                    TileNutrient nutrientReference = _nutrientLocator.LocateNutrient<TileNutrient>(nutrientRelation.nutrientKey);
                    nutrientReference.amountChangedEvent.RemoveListener(Refresh);
                }
            }
            _nutrientLocator = handler.tileNutrientLocator;
            foreach (NutrientRelation nutrientRelation in nutrients)
            {
                TileNutrient nutrientReference = _nutrientLocator.LocateNutrient<TileNutrient>(nutrientRelation.nutrientKey);
                nutrientRelation.nutrientReference = nutrientReference;
                nutrientReference.amountChangedEvent.AddListener(Refresh);
            }
        }
        void Refresh(float arg)
        {
            bool hasNeededNutrientsFlag = true;
            foreach (NutrientRelation nutrientRelation in nutrients)
            {
                float amount = _nutrientLocator.LocateNutrient<TileNutrient>(nutrientRelation.nutrientKey).GetAmount();
                if(amount < nutrientRelation.minAmount)
                {
                    hasNeededNutrientsFlag = false;   
                }
            }
            if (hasNeededNutrientsFlag != _hasNeededNutrients)
            {
                _hasNeededNutrients = hasNeededNutrientsFlag;
                neededNutrientsChangedEvent.Invoke(_hasNeededNutrients);
            }
        }
    }
}