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
            waterTileNutrient.AmmountChangedEvent.AddListener(OnWaterTileNutrientAmmountChanged);
        }

        private void OnDisable()
        {
            waterTileNutrient.AmmountChangedEvent.RemoveListener(OnWaterTileNutrientAmmountChanged);
        }

        private void OnWaterTileNutrientAmmountChanged(float arg0)
        {
            if (transform.childCount == 0)
                return;
            var index = (int)Mathf.Round((transform.childCount - 1) * arg0);
            dirtStateMachine.SetState(dirtStateMachine.transform.GetChild(index).GetComponent<TileDirtState>());
        }
    }
}