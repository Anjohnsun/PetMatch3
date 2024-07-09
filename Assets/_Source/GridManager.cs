using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    private Tile[,] _tileGrid;
    private GridDrawer _gridDrawer;
    private int _iconCount;


    public GridManager(Tile[,] tileGrid, GameIconsSO gameIcons)
    {
        _tileGrid = tileGrid;
        _iconCount = gameIcons.Icons.Count;
    }

    public void InitializeGrid()
    {
        for (int i = 0; i < _tileGrid.GetLength(0); i++)
        {
            for (int j = 0; j < _tileGrid.GetLength(1); j++)
            {
                _tileGrid[i, j].TileValue = Random.Range(0, _iconCount);
            }
        }
    }
}
