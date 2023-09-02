using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemImageUpdater : MonoBehaviour
{
    [SerializeField]private Sprite sprite;
    [SerializeField]private GameObject selectedItemImage;
    [SerializeField]private SelectedItemState selectedItemState;


    private void OnEnable()
    {
        selectedItemState.enterEvent.AddListener(OnEnter);
    }

    private void OnDisable()
    {
        selectedItemState.enterEvent.RemoveListener(OnEnter);
    }

    private void OnEnter()
    {
        selectedItemImage.GetComponent<Image>().sprite = sprite;
    }
}
