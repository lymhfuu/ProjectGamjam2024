using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;

public class LevelDesign : EditorWindow
{
    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LevelDesign));
    }

    
    // 用于存储找到的预制体名称
    private string[] prefabNames;
    // 用于存储找到的预制体路径
    private string[] prefabPaths;
    // 当前选择的预制体索引
    private int selectedIndex = 0;

    GameObject prefab = null;

    string widthstr = "";
    string heightstr = "";
    int width = 0;
    int height = 0;

    HexCell[] cellPrefabList;
    HexCell[] cells;
    
    void OnEnable()
    {
        // 查找所有预制体
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new[] {"Assets/Prefab"});
        prefabPaths = new string[guids.Length];
        prefabNames = new string[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            prefabPaths[i] = AssetDatabase.GUIDToAssetPath(guids[i]);
            prefabNames[i] = System.IO.Path.GetFileNameWithoutExtension(prefabPaths[i]);
        }
        prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPaths[selectedIndex]);
    }

    void OnGUI()
    {
        GUILayout.Label("Select a Prefab", EditorStyles.boldLabel);
        
        //选择预制体
        ChoosePrefab();
        
        //选择地图宽度和高度
        SelectWidthAndHeight();

       

        if (GUILayout.Button("创建地图"))
        {
            if(prefab != null){
                CreateCells();
            }
        }
        if (GUILayout.Button("删除地图"))
        {
            GameObject gridManager = GameObject.Find("GridManager");
            if (gridManager != null)
            {
                // 创建一个列表来存储所有要删除的子对象
                List<GameObject> children = new List<GameObject>();

                // 首先收集所有子对象
                foreach (Transform child in gridManager.transform)
                {
                    children.Add(child.gameObject);
                }      

                // 然后在另一个循环中删除它们
                foreach (GameObject child in children)
                {
                    DestroyImmediate(child);
                }
            }
        }
    }

     private void CreateCells()
    {
        cells = new HexCell[width * height];
        for (int z = 0, i = 0; z < width; z++)
        {
            for (int x = 0; x < height; x++)
            {
                CreateOneCell(x, z, i++);
            }
        }
    }

    void CreateOneCell(int x, int y, int i)
    {
        Vector3 position;
        position.y = (x + y * 0.5f - y /2) *(Hex.innerRadius * 2f);
        position.x = y * Hex.outerRadius * 1.5f;
        position.z = 0 ;
        HexCell cell = cells[i] = Instantiate(prefab).GetComponent<HexCell>();
        
            
        cell.name = y.ToString() + " " + x.ToString();
        Canvas canvas = cell.GetComponentInChildren<Canvas>();
        TMP_Text text = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
        text.text = x.ToString() + "\n" + y.ToString();
        GameObject gridmanager = GameObject.Find("GridManager");
        cell.transform.SetParent(gridmanager.transform, false);
        cell.transform.localPosition = position;
    }

    void ChoosePrefab(){
          EditorGUI.BeginChangeCheck();
        selectedIndex = EditorGUILayout.Popup("Prefab", selectedIndex, prefabNames);
        if (EditorGUI.EndChangeCheck())
        {
            // 当选择变化时的逻辑，例如加载并显示选中的预制体
            Debug.Log($"Selected prefab: {prefabNames[selectedIndex]} at path: {prefabPaths[selectedIndex]}");
            
            // 示例：在场景中实例化选中的预制体
            prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPaths[selectedIndex]);
            //PrefabUtility.InstantiatePrefab(prefab);
        }
    }

    void SelectWidthAndHeight(){
        widthstr = EditorGUILayout.TextField ("地图宽度", widthstr);
        heightstr = EditorGUILayout.TextField ("地图高度", heightstr);
        if(widthstr != "" && heightstr != "") {
            width = int.Parse(widthstr);
            height = int.Parse(heightstr);
        }
    }



}