using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public RectTransform playerIcon;
    public Transform player;

    public int currentFloor;

    List<FloorData> Floors => GameManager.Instance.floors;

    public void ChangeFloor(int floor)
    {
        currentFloor = floor;
        RefreshFloorVisual();
        UpdateMiniMap();
    }

    void RefreshFloorVisual()
    {
        foreach (var f in Floors)
        {
            var img = f.miniMapLine.GetComponent<UnityEngine.UI.Image>();
            img.color = (f.floorIndex == currentFloor)
                ? Color.white
                : new Color(1, 1, 1, 0.3f);
        }
    }

    public void UpdateMiniMap()
    {
        var floors = Floors;

        if (floors == null || floors.Count == 0) return;
        if (currentFloor < 0 || currentFloor >= floors.Count) return;

        FloorData floor = floors[currentFloor];

        float t = Mathf.InverseLerp(
            floor.worldXMin,
            floor.worldXMax,
            player.position.x
        );

        RectTransform line = floor.miniMapLine;
        Rect rect = line.rect;

        float localX = Mathf.Lerp(rect.xMin, rect.xMax, t);
        Vector3 worldPos = line.TransformPoint(new Vector3(localX, 0, 0));

        RectTransform parent = playerIcon.parent as RectTransform;
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            RectTransformUtility.WorldToScreenPoint(null, worldPos),
            null,
            out anchoredPos
        );

        playerIcon.anchoredPosition = anchoredPos;
        //Debug.Log($"X={player.position.x}, min={floor.worldXMin}, max={floor.worldXMax}");
    }

    void Update()
    {
        UpdateMiniMap();
    }
}
