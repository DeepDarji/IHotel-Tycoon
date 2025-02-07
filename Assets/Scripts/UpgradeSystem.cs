using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public GameObject[] floors;
    public int upgradeLevel = 0;
    public int upgradeCost = 30;
    public Text upgradeText;
    private int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("SavedMoney", 0);
        upgradeLevel = PlayerPrefs.GetInt("UpgradeLevel", 0);
        UpdateUpgradeUI();
    }

    public void UpgradeRoom()
    {
        money = PlayerPrefs.GetInt("SavedMoney", 0);
        if (money >= upgradeCost && upgradeLevel < floors.Length)
        {
            money -= upgradeCost;
            PlayerPrefs.SetInt("SavedMoney", money);
            PlayerPrefs.SetInt("UpgradeLevel", ++upgradeLevel);
            floors[upgradeLevel - 1].SetActive(true);
            UpdateUpgradeUI();
        }
    }

    void UpdateUpgradeUI()
    {
        upgradeText.text = "Upgrade Level: " + upgradeLevel;
    }
}
