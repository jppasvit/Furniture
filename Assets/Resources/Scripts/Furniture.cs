using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    /*
     * type = 1 Table
     * type = 2 Shelf
     * type = 3 Lamp
     * type = 4 All
     * type = 0 None
     */ 
    public enum FurnitureEnum { None = 0, Table = 1, Shelf = 2, Lamp = 3, All = 4 }

    public FurnitureEnum type = 0;
}
