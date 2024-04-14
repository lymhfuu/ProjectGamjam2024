using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int height = 6;
    public int width = 6;

    public HexCell[] cellPrefabList;
    public float[] cellWeight;

    HexCell[] cells;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateCells();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefabList[0]);
        
            
        cell.name = y.ToString() + " " + x.ToString();
        Canvas canvas = cell.GetComponentInChildren<Canvas>();
        TMP_Text text = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
        text.text = x.ToString() + "\n" + y.ToString();
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
  
}
