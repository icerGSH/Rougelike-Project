using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    [System.Serializable]
    public class FloorData
    {
        public int floorIndex;      // 楼层编号
        public float worldXMin;     // 该楼层世界 X 最小
        public float worldXMax;     // 该楼层世界 X 最大
        public RectTransform uiLine;// 对应 UI 线
    }

    public List<FloorData> floors;
    public Transform player;
    public RectTransform playerIcon;
    public int currentFloor;

    void UpdateMiniMap()
    {
        if (floors == null || floors.Count == 0) return;
        if (currentFloor < 0 || currentFloor >= floors.Count) return;

        FloorData floor = floors[currentFloor];

        float t = Mathf.InverseLerp(
            floor.worldXMin,
            floor.worldXMax,
            player.position.x
        );

        RectTransform line = floor.uiLine;
        Rect rect = line.rect;

        // 在 uiLine 本地坐标中算位置
        float localX = Mathf.Lerp(rect.xMin, rect.xMax, t);
        Vector3 localPos = new Vector3(localX, 0, 0);

        // 转成世界坐标
        Vector3 worldPos = line.TransformPoint(localPos);

        // 再转成 icon 的父 UI 坐标
        RectTransform parent = playerIcon.parent as RectTransform;
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            RectTransformUtility.WorldToScreenPoint(null, worldPos),
            null,
            out anchoredPos
        );

        playerIcon.anchoredPosition = anchoredPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMiniMap();
    }
}
