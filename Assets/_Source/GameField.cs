using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;

    [SerializeField] private int _rows;
    [SerializeField] private float _xSpacing;
    [SerializeField] private int _columns;
    [SerializeField] private float _ySpacing;
    [SerializeField] private Transform _anchor;

    private Tile[,] _tiles;
    [SerializeField] private GameIconsSO _gameIcons;

    private GridManager _gridManager;
    [SerializeField] GridDrawer _gridDrawer;

    void Start()
    {
        _tiles = new Tile[_rows, _columns];
        GenerateTiles();

        _gridDrawer.Construct(_tiles, _gameIcons);
        _gridManager = new GridManager(_tiles, _gameIcons);

        _gridManager.InitializeGrid();
        _gridDrawer.DrawGrid();
    }

    private void GenerateTiles()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                GameObject newTile = Instantiate(_tilePrefab);

                newTile.transform.localPosition = _anchor.position + new Vector3(
                    j + _xSpacing * j,
                    i + _ySpacing * i);

                _tiles[i, j] = newTile.GetComponent<Tile>();
            }
        }
    }
}
