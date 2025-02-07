using UnityEngine;
using UnityEngine.UI;

public class UnlockSystem : MonoBehaviour
{
    public GameObject lockedRoom;
    public Button unlockButton;
    public int unlockCost = 50;
    private int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("SavedMoney", 0);
        if (PlayerPrefs.GetInt("RoomUnlocked", 0) == 1)
        {
            lockedRoom.SetActive(true);
            unlockButton.gameObject.SetActive(false);
        }
    }

    public void UnlockRoom()
    {
        money = PlayerPrefs.GetInt("SavedMoney", 0);
        if (money >= unlockCost)
        {
            money -= unlockCost;
            PlayerPrefs.SetInt("SavedMoney", money);
            PlayerPrefs.SetInt("RoomUnlocked", 1);
            lockedRoom.SetActive(true);
            unlockButton.gameObject.SetActive(false);
        }
    }
}
