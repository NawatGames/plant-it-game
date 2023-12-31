using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plant
{


    public class SpriteUpdater : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private PlantGrowingState growingState;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnEnable()
        {
            growingState.stateEnterEvent.AddListener(UpdateSprite);
        }

        private void OnDisable()
        {
            growingState.stateEnterEvent.RemoveListener(UpdateSprite);
        }

        public void UpdateSprite()
        {
            spriteRenderer.sprite = sprite;
        }
    }
}