using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public GameObject elevatorUI;
    bool playerInside;

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            elevatorUI.SetActive(true);
            Time.timeScale = 0f; // ‘›Õ£”Œœ∑
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("inside");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            playerInside = false;
    }

    public void SelectFloor(int floor)
    {
        Time.timeScale = 1f;
        elevatorUI.SetActive(false);
        GameManager.Instance.SwitchFloor(floor);
    }
}
