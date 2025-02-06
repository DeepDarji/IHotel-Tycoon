using UnityEngine;

public class RoomUnlocker : MonoBehaviour
{
    public GameObject roomToUnlock;
    public int unlockCost = 500;
    private MoneyManager moneyManager;

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();

        if (PlayerPrefs.GetInt("RoomUnlocked", 0) == 1)
        {
            roomToUnlock.SetActive(true);
            Debug.Log("Room was already unlocked (Loaded from save).");
        }
        else
        {
            roomToUnlock.SetActive(false);
            Debug.Log("Room is locked. Need $" + unlockCost + " to unlock.");
        }
    }

    public void TryUnlockRoom()
    {
        if (moneyManager.money >= unlockCost)
        {
            moneyManager.money -= unlockCost;
            roomToUnlock.SetActive(true);
            PlayerPrefs.SetInt("RoomUnlocked", 1);
            moneyManager.UpdateMoneyUI();
            Debug.Log("Room Unlocked! Remaining Money: $" + moneyManager.money);
        }
        else
        {
            Debug.Log("Not enough money to unlock the room! Need $" + (unlockCost - moneyManager.money) + " more.");
        }
    }
}
