using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryManagernote : MonoBehaviour
{
   public  static InventoryManagernote instance;

   public Inventory  mybag;
   public GameObject slotgrid;
   //public Slot slotprefab;
   public GameObject emptySlot;
   
   public GameObject itembag;
   public List<GameObject> slots=new List<GameObject>();
   public int page=1;
   //public item keycomplete;
   public item nullitem;

   private void Awake() 
    {
        if(instance==null)
        {
            instance =this;
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        
    }
   private void Start()
   {
      gameObject.SetActive(false);
      Refreshitem();
      
   }
   private void OnEnable() 
   {
      
   }
   private void Update() 
   {
     updatebag();
    // keysynthesis();
   }
   
   /*public static void CreatNewItem(item item)
   {
    Slot newitem=Instantiate(instance .slotprefab ,instance.slotgrid .transform.position,Quaternion .identity );
    newitem .gameObject .transform .SetParent (instance .slotgrid .transform );
    newitem.slotitem=item;
    newitem.slotiamge .sprite =item .itemimage ;
    newitem.slotamount.text=item.itemamount.ToString();

   }*/
   public static void Refreshitem()
   {
      for (int i=0;i<instance.slotgrid.transform.childCount;i++)
      {
         
         Destroy(instance.slotgrid.transform.GetChild(i).gameObject);
         instance.slots.Clear();
      }
      for (int i =(0+(instance. page-1)*6);i<(6*instance. page);i++)
      {
         Debug.Log(i);
         //CreatNewItem(instance.mybag.itemList[i]);
         //if((i-(instance. page-1)*6)<instance.mybag.itemList.Count)
         {
         instance.slots.Add(Instantiate(instance.emptySlot,instance.slotgrid.transform));
         //instance.slots[i].transform.SetParent(instance.slotgrid.transform);\
         //if((i-(instance. page-1)*6)<instance.mybag.itemList.Count)
         instance.slots[(i-(instance. page-1)*6)].GetComponent<Slot>().SetupSlot(instance.mybag.itemList[i]);

         }
         
      }
      
   }
   public void openitembag()
   {
       GameEventSystem.instance.Temporarychange("openbag");
      itembag.SetActive(true);
      gameObject.GetComponent<baguianimator>().change();
      itembag.GetComponent<baguianimator>().show();

      
      gameObject.SetActive(false);

   }
   public void buttondown()
   {
      if(instance.mybag.itemList.Count>6*(page))
      {
          page++;
          if(instance.mybag.itemList.Count!=6*(page))
          {
            int Count=instance.mybag.itemList.Count;
            for(int i=0;i<6*(page)-Count;i++)
          {
            Debug.Log("增加一个");
            instance.mybag.itemList.Add(null);

          }

          }
          
          
          Refreshitem();
      }
     
   }
     public void buttonup()
   {
     if(page>1)
      {
          page--;
          Refreshitem();
      }
   }
   public void updatebag()
   {
      for (int i =(0+(instance. page-1)*6);i<(6*instance. page);i++)
      {
         if(instance.mybag.itemList[i]!=null)
         {
            if(instance.mybag.itemList[i].itemamount==0)
            {
               instance.mybag.itemList[i]=null;
               instance.slots[(i-(instance. page-1)*6)].GetComponent<Slot>().SetupSlot(instance.mybag.itemList[i]);

            }
           

            
         }
         
      }
   }
   public item finditem(string _id)
   {
     
      for(int i=0;i<instance.mybag.itemList.Count;i++)
      {
         if(instance.mybag.itemList[i]!=null)
         {
            if(instance.mybag.itemList[i].name==_id)
         {
            return instance.mybag.itemList[i];
         }

         }
         

      }
      return nullitem; 
   }
}