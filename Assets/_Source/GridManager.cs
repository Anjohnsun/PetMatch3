using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    private Tile[,] _tileGrid;
    private GridDrawer _gridDrawer;
    private int _iconCount;


    public GridManager(Tile[,] tileGrid, GridDrawer gridDrawer, GameIconsSO gameIcons)
    {
        _tileGrid = tileGrid;
        _gridDrawer = gridDrawer;
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

    public List<List<Tile>> CheckMatches()
    {
        List<List<Tile>> matches = new List<List<Tile>>();

        int currentType = -1;
        int count = 0;

        for (int i = 0; i < _tileGrid.GetLength(0); i++)
        {
            currentType = _tileGrid[i, 0].TileValue;
            count = 1;

            for (int j = 1; j < _tileGrid.GetLength(1); j++)
            {
                if (_tileGrid[i, j].TileValue == currentType)
                    count++;
                else
                {
                    if (count >= 3)
                    {
                        List<Tile> match = new List<Tile>();
                        for (int x = j; x > j - count + 1; x--)
                        {
                            match.Add(_tileGrid[i, x]);
                        }
                        matches.Add(match);
                    }
                    count = 1;
                    currentType = _tileGrid[i, j].TileValue;
                }
            }

            if (count >= 3)
            {
                List<Tile> match = new List<Tile>();
                for (int x = _tileGrid.GetLength(1)-1; x > _tileGrid.GetLength(1) - 1 - count + 1; x--)
                {
                    match.Add(_tileGrid[i, x]);
                }
                matches.Add(match);
            }
        }

        for (int j = 0; j < _tileGrid.GetLength(1); j++)
        {
            currentType = _tileGrid[0, j].TileValue;
            count = 1;

            for (int i = 1; i < _tileGrid.GetLength(0); i++)
            {
                if (_tileGrid[i, j].TileValue == currentType)
                    count++;
                else
                {
                    if (count >= 3)
                    {
                        List<Tile> match = new List<Tile>();
                        for (int x = i; x > i - count + 1; x--)
                        {
                            match.Add(_tileGrid[x, j]);
                        }
                        matches.Add(match);
                    }
                    count = 1;
                    currentType = _tileGrid[i, j].TileValue;
                }
            }

            if (count >= 3)
            {
                List<Tile> match = new List<Tile>();
                for (int x = _tileGrid.GetLength(0) - 1; x > _tileGrid.GetLength(0) - 1 - count + 1; x--)
                {
                    match.Add(_tileGrid[x, j]);
                }
                matches.Add(match);
            }
        }

        return matches;
    }

    public void RemoveMatches()
    {
        List<List<Tile>> matches = CheckMatches();
        while (matches.Count != 0)
        {
            Debug.Log($"Matches found: {matches.Count}");
            foreach (List<Tile> match in matches)
            {
                //
            }
            FillTiles(matches);

            matches = CheckMatches();
        }
    }

    private void FillTiles(List<List<Tile>> matches)
    {
        foreach(List<Tile> match in matches)
        {
            foreach(Tile tile in match)
            {
                tile.TileValue = Random.Range(0, _iconCount);
            }
        }

        _gridDrawer.RedrawGrid();
    }
}
