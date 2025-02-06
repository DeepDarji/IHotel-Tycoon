using UnityEngine;

public class EarnMoneyButton : MonoBehaviour
{
    public MoneyManager moneyManager;
    public int earnAmount = 50;

    public void EarnMoney()
    {
        moneyManager.AddMoney(earnAmount);
    }
}
