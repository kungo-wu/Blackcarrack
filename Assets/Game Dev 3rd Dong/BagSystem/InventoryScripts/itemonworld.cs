using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemonworld : MonoBehaviour
{
    public item thisItem;
    public Inventory playerInventory;
    private GameObject prompt;
    [Header("该拾取的物品标识")]
    public GameObject promptPrefab;
    public string temporarychange;
    public string Gatheringname;
   /* private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            AddNewItem();
            Destroy (gameObject );

        }
    }*/
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && prompt != null)
        {
        GameEventSystem.instance.Temporarychange("pickitem");
        AddNewItem();
        Destroy (gameObject );
        QuestUIManager. instance.UpdateQuestList();
        if(temporarychange!="")
        {
             GameEventSystem.instance.Singlequest(temporarychange);
             GameEventSystem.instance.Questupdate();

        }
       
        if(Gatheringname!="")
        GameEventSystem.instance.GatheringUpdate(Gatheringname);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            prompt = Instantiate(promptPrefab, transform.position + Vector3.up*0.5f, Quaternion.identity, transform);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Destroy(prompt);
        }
    }
    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        {
          //  playerInventory .itemList .Add (thisItem);
            //InventoryManager.CreatNewItem(thisItem);
            for (int i=0;i<playerInventory.itemList.Count;i++)
            {
                if(playerInventory.itemList[i]==null)
                {
                    playerInventory.itemList[i]=thisItem;
                    thisItem.itemamount = 1;
                    break;
                }
                if(playerInventory.itemList.Count>=6&&playerInventory.itemList[5]!=null)
                {
                    playerInventory.itemList.Add(thisItem);

                }
                
            }
        }
        else
        {
            thisItem.itemamount += 1;
        }
        InventoryManageritem.Refreshitem();
        InventoryManagernote.Refreshitem();
    }
}
