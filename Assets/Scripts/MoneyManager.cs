using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    public Text moneyText;
    public Transform player;
    public Transform character;
    public float earnDistance = 2f;
    public int earnAmount = 10;

    void Start()
    {
        money = PlayerPrefs.GetInt("SavedMoney", 0);
        UpdateMoneyUI();
    }

    void Update()
    {
        if (Vector2.Distance(player.position, character.position) < earnDistance)
        {
            EarnMoney();
        }
    }

    void EarnMoney()
    {
        money += earnAmount;
        PlayerPrefs.SetInt("SavedMoney", money);
        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        moneyText.text = "Money: $" + money.ToString();
    }
}
