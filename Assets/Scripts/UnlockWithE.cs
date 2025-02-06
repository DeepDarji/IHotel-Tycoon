using UnityEngine;
using UnityEngine.UI;

public class UnlockWithE : MonoBehaviour
{
    public MoneyManager moneyManager;
    public GameObject room1;
    public GameObject room2;
    public GameObject pressEText; // "Press E" UI element
    public int unlockCost = 500;
    private bool playerNearby = false;
    private bool roomUnlocked = false; // Ensures unlock happens only once

    void Start()
    {
        pressEText.SetActive(false); // Hide "Press E" initially
    }

    void Update()
    {
        if (playerNearby && !roomUnlocked)
        {
            if (moneyManager.money >= unlockCost)
            {
                pressEText.SetActive(true); // Show "Press E"
            }
            else
            {
                pressEText.SetActive(false); // Hide if not enough money
            }

            if (Input.GetKeyDown(KeyCode.E) && moneyManager.money >= unlockCost)
            {
                UnlockRoom();
            }
        }
        else
        {
            pressEText.SetActive(false); // Always hide when player leaves or room is unlocked
        }
    }

    void UnlockRoom()
    {
        moneyManager.SpendMoney(unlockCost);
        room1.SetActive(false);
        room2.SetActive(true);
        roomUnlocked = true; // Prevents further unlocking
        pressEText.SetActive(false); // Hide text
        Debug.Log("Room Unlocked with E!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left trigger zone.");
            playerNearby = false;
            pressEText.SetActive(false);
        }
    }
}
