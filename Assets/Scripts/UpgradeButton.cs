using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public MoneyManager moneyManager;
    public Button upgradeButton;
    public int upgradeCost = 300;

    void Start()
    {
        upgradeButton.onClick.AddListener(Upgrade);
    }

    void Upgrade()
    {
        if (moneyManager.money >= upgradeCost)
        {
            moneyManager.SpendMoney(upgradeCost);
            Debug.Log("Upgrade Purchased!");
            // Future upgrade features (e.g., increase earning per click)
        }
        else
        {
            Debug.Log("Not enough money to upgrade!");
        }
    }
}
