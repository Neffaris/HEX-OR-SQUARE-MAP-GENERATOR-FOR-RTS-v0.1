using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _selection_Highlight;


    private GameObject _UI_TEXT;
    private GameObject _UI_IMAGE;

    bool _tile_Is_Selected = false;


    //Receive color from Grid_Manager.cs
    public void Init(Color _Color)
    {
        _renderer.color = _Color;
    }

    //Highlight when mouse is over tile
    private void OnMouseEnter() {   
        if ((_renderer.color == Color.yellow) || (_renderer.color == Color.green))
        {
            _highlight.SetActive(true);
        }
    }
    private void OnMouseExit() {
        _highlight.SetActive(false);
    }

    //Tile selected by left mouse button click
    private void OnMouseDown() {
        if ((_renderer.color == Color.yellow) && _tile_Is_Selected == false || (_renderer.color == Color.green) && _tile_Is_Selected == false)
        {
            Debug.Log("Tile has been selected.");
            _tile_Is_Selected = true;
            _selection_Highlight.SetActive(true);

            //Destroy window with info if exist
            DestroyWindowWithStats();

            GenerateWindowWithStats();

        }
        else if ((_renderer.color == Color.yellow) && _tile_Is_Selected == true || (_renderer.color == Color.green) && _tile_Is_Selected == true)
        {
            DestroyWindowWithStats();
            _tile_Is_Selected = false;
            _selection_Highlight.SetActive(false);
        }
        else //if (color == grey or blue)
        { 
            //Close window with info
            DestroyWindowWithStats();
        }
    }

    public void GenerateWindowWithStats()
    {
        ////// Create window with tile stats
        GameObject _ui_Text = new GameObject("UI_TEXT");
        GameObject _ui_Image = new GameObject("UI_IMAGE");

        // Add tag to window
        _ui_Text.tag = "UI_TEXT";
        _ui_Image.tag = "UI_IMAGE";

        // Attach window to main camera
        _ui_Text.transform.parent = Camera.main.transform;
        _ui_Text.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.6f, 0.7f, 1));
        _ui_Image.transform.parent = Camera.main.transform;
        _ui_Image.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.03f, 0.6f, 1));

        var _text_Box = _ui_Text.AddComponent<TextMeshPro>();
        var _image_Box = _ui_Image.AddComponent<UnityEngine.UI.Image>();

        // Convert RGBA to text
        string _name_of_color = "";
        if (_renderer.color == Color.yellow)
        {
            _name_of_color = "��ty";
        }
        if (_renderer.color == Color.green)
        {
            _name_of_color = "Zielony";
        }

        _text_Box.text = "Informacje:"
                        + System.Environment.NewLine
                        + $"Kolor: {_name_of_color}"
                        + System.Environment.NewLine
                        + $"Wsp�rz�dne(x, y): {name}";

        _text_Box.color = Color.black;
        _text_Box.fontSize = 8;

        // Create new texture
        var _square_Texture = new Texture2D(1100, 400, TextureFormat.ARGB32, false);
        //
        var _spriteRenderer = _ui_Image.AddComponent<SpriteRenderer>();

        _square_Texture.Apply();

        _image_Box.sprite = Sprite.Create(_square_Texture, new Rect(0, 0, 1100, 400), new Vector2 (0, 0));

        _spriteRenderer.sprite = _image_Box.sprite;
        //////
    }
    private void DestroyWindowWithStats()
    {
        _UI_TEXT = GameObject.FindWithTag("UI_TEXT");
        Destroy(_UI_TEXT);
        _UI_IMAGE= GameObject.FindWithTag("UI_IMAGE");
        Destroy(_UI_IMAGE);
    }
}
