using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New drop", menuName = "Items/Resource")]
public class DropObjects : ScriptableObject
{
    public GameObject CollectibleObject;
    public int price;
}
