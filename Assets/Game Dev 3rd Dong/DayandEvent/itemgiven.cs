using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemgiven : MonoBehaviour
{
    public string temporarychange;
    public item itemgive;
    public Inventory bag;
    public bool one=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        GameEventSystem.instance.onTemporarychange+=giveitem;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=giveitem;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void giveitem(string _id)
    {
        if(_id==temporarychange&&one)
        {
             if(!bag.itemList.Contains(itemgive))
        {
            GameEventSystem.instance.Temporarychange("pickitem");
          //  playerInventory .itemList .Add (thisItem);
            //InventoryManager.CreatNewItem(thisItem);
            for (int i=0;i<bag.itemList.Count;i++)
            {
                if(bag.itemList[i]==null)
                {
                    bag.itemList[i]=itemgive;
                    itemgive.itemamount = 1;
                    break;
                }
                if(bag.itemList.Count>=6&&bag.itemList[5]!=null)
                {
                    bag.itemList.Add(itemgive);

                }
                
            }
        }
        else
        {
            itemgive.itemamount += 1;
        }
        InventoryManageritem.Refreshitem();
        InventoryManagernote.Refreshitem();
        one=false;
        }
    }
}
