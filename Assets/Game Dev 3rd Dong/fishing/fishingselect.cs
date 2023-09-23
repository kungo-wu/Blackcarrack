using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishingselect : MonoBehaviour
{

    public float shakeRange = 200f; // 晃动范围
    public float frequency = 1f; // 晃动频率
    public float minWidth = 100f; // 宽度下限
    public float maxWidth = 300f; // 宽度上限
    public float widthChangeDurationMin = 1f; // 宽度变化最短时间
    public float widthChangeDurationMax = 3f; // 宽度变化最长时间
    private Vector3 startPosition;
    private float timeOffset;
    private float widthChangeTimer = 0f;
    private float targetWidth = -1f;
    private RectTransform uiTransform;

    public static bool isselectsucess;
    private float relativelocation;
    private float maxselectlocation;
    private float minselectlocation;
    

    void Start()
    {
        uiTransform = GetComponent<RectTransform>();
        startPosition = uiTransform.localPosition;
        timeOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // 每帧计算新位置并应用到UI组件上
        float x = Mathf.PerlinNoise(Time.time * frequency + timeOffset, 0) * 2f - 1f;
        x *= shakeRange;
        uiTransform.localPosition = startPosition + new Vector3(x, 0, 0);

        // 随机变化组件宽度
        if (targetWidth < 0f)
        {
            float width = Random.Range(minWidth, maxWidth);
            targetWidth = width;
            widthChangeTimer = 0f;
        }
        else
        {
            widthChangeTimer += Time.deltaTime;
            float t = widthChangeTimer / Random.Range(widthChangeDurationMin, widthChangeDurationMax);
            float currentWidth = Mathf.Lerp(uiTransform.sizeDelta.x, targetWidth, t);
            uiTransform.sizeDelta = new Vector2(currentWidth, uiTransform.sizeDelta.y);
            if (Mathf.Abs(uiTransform.sizeDelta.x - targetWidth) < 0.1f)
            {
                targetWidth = -1f;
            }
        }
        selectsucess();
    }
    void selectsucess()
    {
        
        relativelocation=fishingcontrol.value*860f-430f;
        maxselectlocation=uiTransform.anchoredPosition.x+ (uiTransform.sizeDelta.x/2f);
        minselectlocation=uiTransform.anchoredPosition.x- (uiTransform.sizeDelta.x/2f);
        if(relativelocation>minselectlocation&& relativelocation<maxselectlocation)
        {
            isselectsucess=true;
            
        }
        else
        {
            isselectsucess=false;

        }
        
    }
}

