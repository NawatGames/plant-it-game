using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private PlantGrowingState growingState;
    [SerializeField] private SpriteRenderer renderer;

    private void OnEnable()
    {
        growingState.stateEnteredEvent.AddListener(UpdateSprite);
    }

    private void OnDisable()
    {
        growingState.stateEnteredEvent.RemoveListener(UpdateSprite);
    }

    public void UpdateSprite()
    {
        renderer.sprite = sprite;
    }

  
}
