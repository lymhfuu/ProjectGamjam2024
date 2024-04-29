using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;
using System.Linq;
using Game.Util;
using System.IO;

public class LevelDesign : EditorWindow
{
    [MenuItem("Window/Level Design")]
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
    HexCell[,] cells;

    void OnEnable()
    {
        // 查找所有预制体
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new[] { "Assets/Resources/Prefabs/Prefab" });
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
            if (prefab != null)
            {
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
        //选择预制体
        ChoosePrefab();
        if (GUILayout.Button("替换地块"))
        {
            if (UnityEditor.Selection.transforms.Length == 0)
            {
                Debug.LogError("请选中一个地块");
                return;
            }
            HexCell deleteObj = UnityEditor.Selection.transforms[0].GetComponent<HexCell>();
            string name = deleteObj.name;
            Vector3 pos = deleteObj.transform.position;
            Quaternion rot = deleteObj.transform.rotation;
            int x = deleteObj.HeightIndex;
            int y = deleteObj.WidthIndex;
            int index = deleteObj.transform.GetSiblingIndex();
            DestroyImmediate(deleteObj.gameObject);
            GameObject gridmanager = GameObject.Find("GridManager");
            HexCell cell = Instantiate(prefab, pos, rot, gridmanager.transform).GetComponent<HexCell>();
            cells[x, y] = cell;
            cell.gameObject.name = name;
            cell.WidthIndex = y;
            cell.HeightIndex = x;
            Canvas canvas = cell.GetComponentInChildren<Canvas>();
            TMP_Text text = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
            text.text = x.ToString() + "\n" + y.ToString();
            cell.transform.SetSiblingIndex(index);
        }

        if (GUILayout.Button("保存地图"))
        {

            Mapdata map = new Mapdata();
            map.height = cells.GetLength(0);
            map.width = cells.GetLength(1);
            map.cells = new HexType[map.height * map.width];
            for (int y = 0, i = 0; y < map.width; y++)
            {
                for (int x = 0; x < map.height; x++)
                {
                    map.cells[i++] = cells[x, y].Type;
                }
            }
            File.WriteAllText("Assets/Resources/MapData/MapData.json", JsonUtil.ToJson(map));
        }
    }



    void CreateCells()
    {
        cells = new HexCell[height, width];
        for (int y = 0, i = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
                CreateOneCell(x, y, i++);
            }
        }
    }

    void CreateOneCell(int x, int y, int i)
    {
        Vector3 position;
        position.y = (x + y * 0.5f - y / 2) * (Hex.innerRadius * 2f);
        position.x = y * Hex.outerRadius * 1.5f;
        position.z = 0;
        HexCell cell = cells[x, y] = Instantiate(prefab).GetComponent<HexCell>();
        cell.WidthIndex = y;
        cell.HeightIndex = x;

        cell.name = y.ToString() + " " + x.ToString();
        Canvas canvas = cell.GetComponentInChildren<Canvas>();
        TMP_Text text = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
        text.text = x.ToString() + "\n" + y.ToString();
        GameObject gridmanager = GameObject.Find("GridManager");
        cell.transform.SetParent(gridmanager.transform, false);
        cell.transform.localPosition = position;
    }

    void ChoosePrefab()
    {
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

    void SelectWidthAndHeight()
    {
        widthstr = EditorGUILayout.TextField("地图宽度", widthstr);
        heightstr = EditorGUILayout.TextField("地图高度", heightstr);
        if (widthstr != "" && heightstr != "")
        {
            width = int.Parse(widthstr);
            height = int.Parse(heightstr);
        }
    }



}