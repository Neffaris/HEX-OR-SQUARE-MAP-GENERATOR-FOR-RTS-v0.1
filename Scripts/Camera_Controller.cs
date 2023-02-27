using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Camera_Controller : MonoBehaviour
{
    Camera _camera;
    [SerializeField] float _camera_Speed = 0.03f;
    int _border_Size = 425;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {    
        int _distance_To_Top = _camera.pixelHeight - (int)Input.mousePosition.y;
        int _distance_To_Bottom = (int)Input.mousePosition.y;
        int _distance_To_Right = _camera.pixelWidth - (int)Input.mousePosition.x;
        int _distance_To_Left = (int)Input.mousePosition.x;

        if (_distance_To_Top < _border_Size && _distance_To_Top > 0 && Input.GetKey(KeyCode.Mouse1))
        {
            _camera.transform.position += Vector3.up * _camera_Speed;
        }
        else if (_distance_To_Bottom < _border_Size && _distance_To_Bottom > 0 && Input.GetKey(KeyCode.Mouse1))
        {
            _camera.transform.position += Vector3.down * _camera_Speed;
        }
        if (_distance_To_Left < _border_Size && _distance_To_Left > 0 && Input.GetKey(KeyCode.Mouse1))
        {
            _camera.transform.position += Vector3.left * _camera_Speed;
        }
        else if (_distance_To_Right < _border_Size && _distance_To_Right > 0 && Input.GetKey(KeyCode.Mouse1))
        {
            _camera.transform.position += Vector3.right * _camera_Speed;
        }
    }

}
 
