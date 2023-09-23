using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relocateclick : MonoBehaviour
{
    public GameObject dialogueImageObj;
    RectTransform rectTransform;

    RectTransform pointer = new RectTransform();
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = dialogueImageObj.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(rectTransform.anchoredPosition.x+(rectTransform.rect.width/2), rectTransform.anchoredPosition.y);
    }
}
