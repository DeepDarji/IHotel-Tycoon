using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public MoneyManager moneyManager;
    public int upgradeCost = 300;
    public Text upgradeText;
    private int level = 1;

    public void Upgrade()
    {
        if (moneyManager.SpendMoney(upgradeCost))
        {
            level++;
            upgradeCost += 200; // Increase price
            upgradeText.text = "Upgrade: $" + upgradeCost;
            Debug.Log("Upgraded to level " + level);
        }
    }
}
