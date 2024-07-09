using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    private Tile[,] _tileGrid;
    private GameIconsSO _gameIcons;

    public void Construct(Tile[,] tileGrid, GameIconsSO gameIcons)
    {
        _tileGrid = tileGrid;
        _gameIcons = gameIcons;
    }

    public void DrawGrid()
    {
        for (int i = 0; i < _tileGrid.GetLength(0); i++)
        {
            for (int j = 0; j < _tileGrid.GetLength(1); j++)
            {
                _tileGrid[i, j].ConnectedSprite.sprite = _gameIcons.Icons[_tileGrid[i, j].TileValue];
            }
        }
    }
}
