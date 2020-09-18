using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    enum Colors{
        RED,
        GREEN,
        BLUE
    }
    [SerializeField]
    private Color[] colors = {
        Color.red,
        Color.green,
        Color.blue
    };

    public GameObject colorPreview;
    public Texture2D reset;
    public Material clothes;
    private int id = 0;
    public Button prev;
    public Button next;
    private Image img;


    void Start()
    {
        img = colorPreview.GetComponent<Image>();
        UpdateColor();
        
        
        
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)){
            ApplyColor();
        }
    }

    public void NextColor(){
        if(id + 1 < colors.Length){
            id++;
        }
        else{
            id = 0;
        }
        UpdateColor();
    }
    public void PreviousColor(){
        if(id - 1 > 0){
            id--;
        }
        else{
            id = colors.Length-1;
        }
        UpdateColor();
    }
    private void UpdateColor(){
        img.color = colors[id];
        ApplyColor();
    }
    private void ApplyColor(){
        Texture2D texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        Color[] col = reset.GetPixels();

        int pixelsChanged = 0;

        for(int i = 0; i < col.Length; i++){
            if(col[i] == Color.white){
                col[i] = colors[id]; 
                pixelsChanged++;
                //col[i] = Color.white; 
            }
        }
        Debug.Log("Changed " + pixelsChanged + " Pixels");

        texture.SetPixels(col);
        texture.Apply(false);
        clothes.SetTexture("_BaseColorMap", texture);   

        Debug.Log("Applied!");
    }
}
