using System.Collections;
using System.Collections.Generic;
using Handler;
using Interacts;
using Unity.VisualScripting;
using UnityEngine;

namespace GrowSystem.PlantInteracts
{

    public class PlantSpawner : MonoBehaviour
    {
        public void SpawnPlant(SeedProfileItemSO seedProfileItemSo)
        {
            seedProfileItemSo.InteractWith(GetComponent<TileHandler>());
        }
    }
}
