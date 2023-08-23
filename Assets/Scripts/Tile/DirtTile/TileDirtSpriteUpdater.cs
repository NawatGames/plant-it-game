using System;
using UnityEngine;

namespace DirtTile
{
    public class TileDirtSpriteUpdater : MonoBehaviour
    {
        [SerializeField]private Sprite sprite;
        [SerializeField]private SpriteRenderer spriteRenderer;
        [SerializeField]private TileDirtState tileDirtState;
        private void OnEnable()
        {
            tileDirtState.enterEvent.AddListener(OnEnter);
        }

        private void OnDisable()
        {
            tileDirtState.enterEvent.RemoveListener(OnEnter);
        }

        private void OnEnter()
        {
            spriteRenderer.sprite = sprite;
        }
    }
}