using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Plant/Profile", fileName = "New Profile")]
public class PlantProfileSO : ScriptableObject
{
    public GameObject prefab;
    public UnityEvent plantSelectEvent, plantUnselectEvent;
}