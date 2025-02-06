using UnityEngine;
using UnityEngine.UI;

public class RoomUnlockUI : MonoBehaviour
{
    public GameObject pressEText;

    void Start()
    {
        pressEText.SetActive(false);
    }

    public void ShowPrompt(bool show)
    {
        pressEText.SetActive(show);
    }
}
