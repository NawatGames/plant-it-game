using System;
using UnityEngine;

namespace DirtTile
{
    public class DirtTileStateController : MonoBehaviour
    {
        [SerializeField]private TileNutrient waterTileNutrient;
        [SerializeField]private TileDirtStateMachine dirtStateMachine;

        private void OnEnable()
        {
            waterTileNutrient.amountChangedEvent.AddListener(OnWaterTileNutrientAmountChanged);
        }

        private void OnDisable()
        {
            waterTileNutrient.amountChangedEvent.RemoveListener(OnWaterTileNutrientAmountChanged);
        }

        private void OnWaterTileNutrientAmountChanged(float amount)
        {
            if (transform.childCount == 0)
                return;
            var index = (int)Mathf.Round((transform.childCount - 1) * amount);
            dirtStateMachine.SetState(dirtStateMachine.transform.GetChild(index).GetComponent<TileDirtState>());
        }
    }
}