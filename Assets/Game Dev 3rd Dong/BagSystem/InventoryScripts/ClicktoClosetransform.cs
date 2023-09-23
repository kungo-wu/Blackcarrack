using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicktoClosetransform : MonoBehaviour
{
    public RectTransform referenceTransform; // 参考UI组件的RectTransform
    public float xOffset = 0f; // 横向微调值
    public float yOffset = 0f; // 纵向微调值

    private void Update()
    {
        if (referenceTransform != null)
        {
            // 获取参考UI组件的位置
            Vector3 referencePosition = referenceTransform.position;

            // 获取要停留的UI组件的RectTransform
            RectTransform rectTransform = GetComponent<RectTransform>();

            // 计算新的位置，使UI组件位于参考UI组件的右上角，并加入微调值
            float xAdjustment = referenceTransform.rect.width / 2 + rectTransform.rect.width / 2 + xOffset;
            float yAdjustment = referenceTransform.rect.height / 2 - rectTransform.rect.height / 2 - yOffset;
            Vector3 newPosition = new Vector3(referencePosition.x + xAdjustment, referencePosition.y + yAdjustment, referencePosition.z);

            // 设置UI组件的新位置
            rectTransform.position = newPosition;
        }
    }
}
