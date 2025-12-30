using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorData:MonoBehaviour
{
    public int floorIndex;
    public GameObject floorRoot;   // Floor_0 / Floor_1
    public Transform spawnPoint;   // 玩家出生点
    public float worldXMin;
    public float worldXMax;
    public RectTransform miniMapLine;
}
