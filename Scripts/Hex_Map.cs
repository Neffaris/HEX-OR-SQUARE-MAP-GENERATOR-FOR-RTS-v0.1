using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Map : MonoBehaviour
{
    //---------------------- Change Vector2(x, y) to change size of map 1000 1000
    private Vector2 _map_Size = new Vector2(100, 100);

    [SerializeField] private Tile _hex;
    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject _hexes;
    //public GameObject _hexes;

    void Start()
    {
        Generate_Grid();
    }

    void Generate_Grid()
    {
        List<Color> _available_Colors = new List<Color>();

        //Add color to list of available colors


        // Map size: 100x100 = 6000, 1000x1000 = 600 000
        for (int i = 0; i < 6000; i++)
            _available_Colors.Add(Color.blue);
        // Map size: 100x100 = 1000, 1000x1000 = 100 000
        for (int i = 0; i < 1000; i++)
            _available_Colors.Add(Color.green);
        // Map size: 100x100 = 500, 1000x1000 = 50 000y
        for (int i = 0; i < 500; i++)
            _available_Colors.Add(Color.yellow);
        // Map size: 100x100( = 2500, 1000x1000 = 250 000
        for (int i = 0; i < 2500; i++)
            _available_Colors.Add(Color.grey);
        //Add new colors here
        //for (int i = 0; i < 100; i++)
        //_available_Colors.Add(Color.black);

        for (int x = 0; x < _map_Size.x; x++)
        {
            for (int y = 0; y < _map_Size.y; y++)
            {
                Vector2 pos = new Vector2(x, y * 0.86f);

                if (y % 2 == 0)
                    pos.x += 0.5f;
                    var _spawned_Tile = Instantiate(_hex, pos, Quaternion.identity, _hexes.transform);
                    _spawned_Tile.name = $"{x}, {y}";

                    int _random_Color_Number = Random.Range(0, _available_Colors.Count);

                    Color _random_Color_Color = _available_Colors[_random_Color_Number];

                    _available_Colors.RemoveAt(_random_Color_Number);

                    _spawned_Tile.Init(_random_Color_Color);
            }
        }

        _camera.transform.position = new Vector3((float)_map_Size.x / 2 - 0.5f, (float)_map_Size.y / 2 - 0.5f, -10);
    }
}

