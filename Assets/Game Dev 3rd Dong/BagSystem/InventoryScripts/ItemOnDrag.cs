using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
   public Vector3 original;
   public void OnBeginDrag(PointerEventData eventData)
   {
    Slot.ondrag=true;
    original=transform.parent.position;
    //transform.parent.SetParent(transform.parent.parent);
    //transform.parent.position=eventData.position;
    transform.parent.GetComponent<CanvasGroup>().blocksRaycasts=false;

   }
   
   public void OnDrag(PointerEventData eventData)
   {
     transform.parent.position=eventData.position;
     Slot.ondrag=true;
     //Debug.Log(Slot.ondrag);

   }
   
   public void OnEndDrag(PointerEventData eventData)
   {
   
    
    /*if(eventData.pointerCurrentRaycast.gameObject.name=="slot(Clone)")
    {
      Debug.Log("检测成功");
        //transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
        //transform.parent.position=eventData.pointerCurrentRaycast.gameObject.transform.position;
        eventData.pointerCurrentRaycast.gameObject.transform.position=original;
       // eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
       GetComponent<CanvasGroup>().blocksRaycasts= true;
        
        
    }*/
    if(eventData.pointerCurrentRaycast.gameObject.name=="itemimage")
    {
      //Debug.Log("检测成功");
        //transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
        transform.parent.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
        eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position=original;
       // eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
       
        
        
    }
    else 
    {
        transform.parent.position=original;
        
    }
    
   
    transform.parent.GetComponent<CanvasGroup>().blocksRaycasts=true;
    Slot.ondrag=false; 
     //transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
     
   }
    public void OnMouseDown() 
    {
        if(Input.GetMouseButton(1))
        {
            Debug.Log("1");
        }
    } 
}
