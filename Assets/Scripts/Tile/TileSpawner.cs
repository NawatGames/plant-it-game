using System;
using System.Collections;
using System.Collections.Generic;
using Handler;
using Tile;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject root;

    private void Start()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                SpawnTile(new Vector2Int(x, y));
            }
        }
    }

    TileHandler SpawnTile(Vector2Int point)
    {
        Vector3 position = tilemap.CellToWorld((Vector3Int)point);
        GameObject clone = Instantiate(tilePrefab, position, Quaternion.identity);
        clone.transform.parent = root.transform;
        TileHandler handler = clone.GetComponentInChildren<TileHandler>();
        if(handler == null) throw new Exception("TileHandler não encontrado");
        return handler;
    }
}