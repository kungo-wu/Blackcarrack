using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   public item slotitem;
   public Image slotiamge;
   public Text  slotamount;
   public string slotInfo;

   public GameObject itemInslot;
   public GameObject description;
   public TextMeshProUGUI iteminformation;
   private  bool click;
   public static  bool ondrag;
   public GameObject ClicktoShow;
   public float padding = 0.8f;
   private void Start() 
   {
      ClicktoShow=GameObject.Find("Bag").transform.Find("ClicktoShow").gameObject;
      iteminformation.text=slotInfo;  
      ClicktoShow.SetActive(false);
   }
   private void Update() 
   {
        if(!ondrag)
        {
            description.SetActive(click);
            //Debug.Log(ondrag);

        }
        if(ondrag)
        {
          description.SetActive(false);  
        }
        if (Input.GetMouseButtonDown(1)) // 这里假设左键点击
        {
            HandleInventoryItemClick();
            Debug.Log("click");
        }
         
      
   }

  public void SetupSlot(item item)
  {
   if(item == null)
   {
      itemInslot.SetActive(false);
      
      return;

   }
   slotitem=item;
   slotiamge.sprite=item.itemimage;
   slotamount.text=item.itemamount.ToString();
   slotInfo=item.iteminfo;
  }
 
        
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        click=true;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        click=false;
    }
    void HandleInventoryItemClick()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);

            // 设置PointerEventData的位置为鼠标位置
            eventData.position = Input.mousePosition;

            // 创建一个列表来存储射线检测结果
            var results = new List<RaycastResult>();

            // 使用Graphic Raycaster执行射线检测
            GraphicRaycaster raycaster = GetComponent<GraphicRaycaster>();
            raycaster.Raycast(eventData, results);

            // 遍历射线检测结果
            foreach (RaycastResult result in results)
            {
                // 获取碰撞到的UI元素
                GameObject hitObject = result.gameObject;

                // 在这里执行右键点击UI元素后的逻辑
                if (hitObject.CompareTag("Slot"))
                {
                    // 在这里执行右键点击UI元素后的逻辑
                    ItemClicktoRead();

                    // 你可以在这里执行特定的操作

                    // 跳出循环，因为我们只关心第一个符合条件的UI元素
                    break;
                }
            }
    }
    void ItemClicktoRead()
    {
        if(slotitem!=null)
        {
           if(slotitem.use)
           {
             ClicktoShow.SetActive(true);
            float imageWidth = slotitem.clicktoshow.bounds.size.x;
            float imageHeight = slotitem.clicktoshow.bounds.size.y;

            // 计算图像的长宽比
            float aspectRatio = imageWidth / imageHeight;

            // 获取UI组件的RectTransform
            RectTransform rectTransform = ClicktoShow.GetComponent<Image>().rectTransform;

            // 调整UI组件的大小以匹配图像的长宽比
            float newWidth = (rectTransform.rect.height - 2 * padding) * aspectRatio;
            rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.rect.height - 2 * padding);
             ClicktoShow.GetComponent<Image>().sprite=slotitem.clicktoshow;
           }
        }

    }
        
    
}
