using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RelocatePointerLocation : MonoBehaviour
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
        GetComponent<RectTransform>().anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y-(rectTransform.rect.height+20));
    }
}
