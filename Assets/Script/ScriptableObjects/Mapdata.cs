using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/CreateMapdata")]
public class Mapdata : ScriptableObject
{
    public int height = 0;
    public int width = 0;
    public HexType[] cells ;
}
