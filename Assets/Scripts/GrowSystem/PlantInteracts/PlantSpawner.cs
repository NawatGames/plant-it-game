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
        [SerializeField] private PlantReference plantReference;
        [SerializeField] private TileHandler tileHandler;
        public PlantHandler SpawnPlant(GameObject plantPrefab)
        {
            //TODO: dar merge, procurar dentro do prefab do tile como é feita a referencia para a planta que esta plantada dentro do tile
            //TODO: procurar como é a maneira correta de spawnar a planta, e disparar os eventos;

            return null;
        }
    }
}
