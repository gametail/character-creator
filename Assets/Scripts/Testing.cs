using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject prefab1;
    public static GameObject prefab;
    private Grid grid;
    private GameObject[,] textArray = new GameObject[10,5];

    private void Start()
    {
        prefab = prefab1;
        grid = new Grid(10, 5, 1f);
        CreateText(grid);

    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            //Vector3 vec;
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
/*
            float entry;

            if(plane.Raycast(ray, out entry)){
                vec = ray.GetPoint(entry);
                vec = new Vector3(Mathf.FloorToInt(vec.x), Mathf.FloorToInt(vec.z), 0); 
                Debug.Log(vec);
                grid.SetValue(vec, 5);
                UpdateText(grid);
            }
*/
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                grid.SetValue(grid.GetXY(hit.point).x,grid.GetXY(hit.point).y , 5);
                Debug.Log(hit.point);
                Debug.Log(grid.GetXY(hit.point).x +" , " +grid.GetXY(hit.point).y);
                UpdateText(grid);
            }

        }



        


        if(Input.GetKeyDown(KeyCode.P)){
            grid.printGrid();
        }
    }

    public static void CreateCube(Vector3 position){
        
        GameObject cube = Instantiate(prefab, new Vector3(position.x, -0.5f, position.y), Quaternion.identity);
        cube.tag = "Selectable";
        
    }
    public void CreateText(Grid grid){
        for(int y = 0; y < grid.getHeight(); y++){
            for(int x = 0; x < grid.getWidth(); x++){
                GameObject text = new GameObject();
                TextMesh t = text.AddComponent<TextMesh>();
                t.text = grid.GetValue(x,y).ToString();
                t.characterSize = 0.02f;
                t.anchor = TextAnchor.MiddleCenter;
                t.alignment = TextAlignment.Center;
                t.fontSize = 355;
                t.color = Color.black;
                t.transform.localEulerAngles += new Vector3(90, 0, 0);
                t.transform.localPosition = new Vector3(x, 0.1f, y);
                textArray[x,y] = text;
            }
        }
    }
    public void UpdateText(Grid grid){
        for(int y = 0; y < grid.getHeight(); y++){
            for(int x = 0; x < grid.getWidth(); x++){
                TextMesh t = textArray[x,y].GetComponent<TextMesh>();
                t.text = grid.GetValue(x,y).ToString();
            }
        }
    }
    
}
