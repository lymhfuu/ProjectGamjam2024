using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HexCellEmpty : HexCell
{
    public HexCellEmpty()
    {
        Type = HexType.Empty;
    }
}
