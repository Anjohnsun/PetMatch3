using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameIcons", menuName = "SO/NewGameIcons")]
public class GameIconsSO : ScriptableObject
{
    [SerializeField] private List<Sprite> _icons;

    public List<Sprite> Icons => _icons;
}
