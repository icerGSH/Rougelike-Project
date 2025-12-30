using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject chestPanel;
    public Text chestText;

    public string itemName = "金币";
    public int itemCount = 10;

    private bool playerInRange = false;
    private bool opened = false;
    private bool panelOpen = false;

    void Update()
    {
        // 打开宝箱
        if (playerInRange && !opened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }

        // 关闭窗口
        if (panelOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }
    }

    void OpenChest()
    {
        opened = true;
        panelOpen = true;

        chestPanel.SetActive(true);
        chestText.text = $"获得了 {itemName} x{itemCount}";
    }

    void ClosePanel()
    {
        panelOpen = false;
        chestPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
