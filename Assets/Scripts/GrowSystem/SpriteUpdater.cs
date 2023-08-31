using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private PlantState state;
    [SerializeField] private SpriteRenderer renderer;

    private void OnEnable()
    {
        state.stateEnteredEvent.AddListener(UpdateSprite);
    }

    private void OnDisable()
    {
        state.stateEnteredEvent.RemoveListener(UpdateSprite);
    }

    public void UpdateSprite()
    {
        renderer.sprite = sprite;
    }

  
}
