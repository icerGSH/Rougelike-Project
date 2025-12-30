using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<FloorData> floors;
    public int currentFloor;

    public Transform player;
    public MiniMap miniMap;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SwitchFloor(currentFloor);
    }

    public void SwitchFloor(int targetFloor)
    {
        if (targetFloor < 0 || targetFloor >= floors.Count)
            return;

        // 关闭当前楼层
        for (int i = 0; i < floors.Count; i++)
            floors[i].floorRoot.SetActive(i == targetFloor);

        currentFloor = targetFloor;

        // 传送玩家
        player.position = floors[currentFloor].spawnPoint.position;

        // 更新小地图
        miniMap.ChangeFloor(currentFloor);
    }


}
