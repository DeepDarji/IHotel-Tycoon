using UnityEngine;
using UnityEngine.UI;

public class RoomUnlocker : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    public GameObject pressEText;
    public MoneyManager moneyManager;
    public int unlockCost = 500;
    private bool playerNearby = false;

    void Start()
    {
        pressEText.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && moneyManager.money >= unlockCost)
        {
            pressEText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                UnlockRoom();
            }
        }
        else
        {
            pressEText.SetActive(false);
        }
    }

    public void UnlockRoom()
    {
        if (moneyManager.SpendMoney(unlockCost))
        {
            room1.SetActive(false);
            room2.SetActive(true);
            pressEText.SetActive(false);
            Debug.Log("Room Unlocked!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            pressEText.SetActive(false);
        }
    }
}
