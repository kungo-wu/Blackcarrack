using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/New Item")]
public class item : ScriptableObject
{
    public string itemname;
    public Sprite itemimage;  
    public int itemamount;
    [TextArea ]
    public string iteminfo;
    public bool use;
    public Sprite clicktoshow;

}
