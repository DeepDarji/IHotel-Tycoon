using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    public Text moneyText;

    void Start()
    {
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            UpdateMoneyUI();
            return true; // Success
        }
        return false; // Not enough money
    }

    void UpdateMoneyUI()
    {
        moneyText.text = "$" + money.ToString();
    }
}
