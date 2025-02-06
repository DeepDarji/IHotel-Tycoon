using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;  
    public int money = 100; 

    void Start()
    {
        Debug.Log("Game Started. Initial Money: $" + money);
        UpdateMoneyUI();
    }

    public void EarnMoney()
    {
        money += 50;  
        Debug.Log("Earned $50! Total Money: $" + money);
        UpdateMoneyUI();
    }

    public void UpdateMoneyUI()
    {
        moneyText.text = "Money: $" + money;
        Debug.Log("Money UI Updated: " + moneyText.text);
    }
}
