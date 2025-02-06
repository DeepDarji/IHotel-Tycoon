using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int upgradeCost = 200;
    private MoneyManager moneyManager;
    private int incomePerClick = 50;

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();

        if (PlayerPrefs.HasKey("UpgradeLevel"))
        {
            incomePerClick = PlayerPrefs.GetInt("UpgradeLevel");
            Debug.Log("Loaded Upgrade Level: Earn $" + incomePerClick + " per click.");
        }
        else
        {
            Debug.Log("No upgrade found. Default earnings per click: $" + incomePerClick);
        }
    }

    public void UpgradeRoom()
    {
        if (moneyManager.money >= upgradeCost)
        {
            moneyManager.money -= upgradeCost;
            incomePerClick += 50;
            PlayerPrefs.SetInt("UpgradeLevel", incomePerClick);
            moneyManager.UpdateMoneyUI();
            Debug.Log("Room Upgraded! New Earnings per Click: $" + incomePerClick + ". Remaining Money: $" + moneyManager.money);
        }
        else
        {
            Debug.Log("Not enough money to upgrade! Need $" + (upgradeCost - moneyManager.money) + " more.");
        }
    }

    public int GetIncome()
    {
        return incomePerClick;
    }
}
