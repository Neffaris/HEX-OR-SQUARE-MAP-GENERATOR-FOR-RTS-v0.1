using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Map : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tile_prefab;

    [SerializeField] private Transform _camera;

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

        for (int x = 0; x < _width; x++) 
        {
            for (int y = 0; y < _height; y++)
            {
                var _spawned_Tile = Instantiate(_tile_prefab, new Vector3(x, y), Quaternion.identity);
                _spawned_Tile.name = $"{x}, {y}";

                int _random_Color_Number = Random.Range(0, _available_Colors.Count); 
                Color _random_Color_Color = _available_Colors[_random_Color_Number];
                _available_Colors.RemoveAt(_random_Color_Number);

                _spawned_Tile.Init(_random_Color_Color);
            }

        }

        _camera.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, - 10);
    }
}

