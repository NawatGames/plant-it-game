using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutrientLocator : MonoBehaviour
{
    public enum NutrientKey
    {
        Water,
        Nitrogen,
        Potassium,
        Phosphor,
        Iron,
        Zinc,
        Magnesium
    }

    public T LocateNutrient<T>(NutrientKey key)
    {
        Debug.Log(key.ToString());
        return transform.Find(key.ToString()).GetComponent<T>();
    }
}