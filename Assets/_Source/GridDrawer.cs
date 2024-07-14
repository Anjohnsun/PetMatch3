using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class GridDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameIconsSO _gameIcons;

    [SerializeField] private Vector2Int _size;
    [SerializeField] private Vector2 _spacing;

    [SerializeField] private Transform _anchor;

    private Tile[,] _tiles;


    private GridManager _gridManager;

    void Start()
    {
        _tiles = new Tile[_size.x, _size.y];
        GenerateTiles();

        _gridManager = new GridManager(_tiles, this, _gameIcons);

        _gridManager.InitializeGrid();
        RedrawGrid();
        _gridManager.RemoveMatches();
    }

    private void GenerateTiles()
    {
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                GameObject newTile = Instantiate(_tilePrefab);

                newTile.transform.localPosition = _anchor.position + new Vector3(
                    j + _spacing.x * j,
                    i + _spacing.y * i);

                _tiles[i, j] = newTile.GetComponent<Tile>();
            }
        }
    }

    public void RedrawGrid()
    {
        for (int i = 0; i < _tiles.GetLength(0); i++)
        {
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                _tiles[i, j].ConnectedSprite.sprite = _gameIcons.Icons[_tiles[i, j].TileValue];
            }
        }
    }
}
