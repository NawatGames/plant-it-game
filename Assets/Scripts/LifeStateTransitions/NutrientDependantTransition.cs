using UnityEngine;

namespace LifeStateTransitions
{
    public class NutrientDependantTransition : LifeStateTransition
    {
        [SerializeField] private TileReference tileReference;
        [SerializeField] protected float minAmount = .1f;
        protected NutrientLocator nutrientLocator;
        protected TileNutrient water;
        protected TileNutrient nitrogen;
        protected TileNutrient potassium;
        protected TileNutrient phosphor;
        protected TileNutrient iron;
        protected TileNutrient zinc;
        protected TileNutrient magnesium;
        protected TileNutrient[] nutrients;
        protected virtual void Awake()
        {
            nutrientLocator = tileReference.GetHandler().tileNutrientLocator;
            water = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Water);
            nitrogen = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Nitrogen);
            potassium = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Potassium);
            phosphor = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Phosphor);
            iron = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Iron);
            zinc = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Zinc);
            magnesium = nutrientLocator.LocateNutrient<TileNutrient>(NutrientLocator.NutrientKey.Magnesium);
            nutrients = new TileNutrient[7] { water, nitrogen, potassium, phosphor, iron, zinc, magnesium };
        }
        protected override void OnStateEntered()
        {
            water.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
            nitrogen.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
            potassium.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
            phosphor.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
            iron.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
            zinc.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
            magnesium.amountChangedEvent.AddListener(OnNutrientAmountChangedEvent);
        }
        protected override void OnStateLeft()
        {
            water.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
            nitrogen.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
            potassium.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
            phosphor.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
            iron.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
            zinc.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
            magnesium.amountChangedEvent.RemoveListener(OnNutrientAmountChangedEvent);
        }

        protected virtual void OnNutrientAmountChangedEvent(float amount)
        {
            
        }
    }
}