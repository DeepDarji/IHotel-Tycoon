using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int money = 0;
    public int moneyRequired = 10;

    public GameObject room2, room3, room4;
    public GameObject room2Entry, room3Entry, room4Entry;

    private GameObject roomToUnlock;
    private GameObject entryToHide;

    public Text moneyText;
    public Text popupText;

    public JoystickController joystick; // Reference to joystick controller

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Hide locked rooms
        room2.SetActive(false);
        room3.SetActive(false);
        room4.SetActive(false);

        UpdateMoneyUI();
        popupText.text = ""; // Hide popup at start

        Debug.Log("Game Started! Money: " + money);
    }

    private void Update()
    {
        // ?? Use Joystick Input
        movement.x = joystick.Horizontal();
        movement.y = joystick.Vertical();
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed; // Apply movement
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Character"))
        {
            money += 5;
            UpdateMoneyUI();
            Debug.Log("Earned 5 money! Total: " + money);
        }

        if (other.CompareTag("room_2_entry"))
        {
            if (money >= moneyRequired)
            {
                ShowPopup("Press 'Unlock' to unlock Room 2");
                roomToUnlock = room2;
                entryToHide = room2Entry;
            }
            else
            {
                ShowPopup("Not enough money! Need " + (moneyRequired - money) + " more.");
                roomToUnlock = null;
            }
        }
        else if (other.CompareTag("room_3_entry"))
        {
            if (money >= moneyRequired)
            {
                ShowPopup("Press 'Unlock' to unlock Room 3");
                roomToUnlock = room3;
                entryToHide = room3Entry;
            }
            else
            {
                ShowPopup("Not enough money! Need " + (moneyRequired - money) + " more.");
                roomToUnlock = null;
            }
        }
        else if (other.CompareTag("room_4_entry"))
        {
            if (money >= moneyRequired)
            {
                ShowPopup("Press 'Unlock' to unlock Room 4");
                roomToUnlock = room4;
                entryToHide = room4Entry;
            }
            else
            {
                ShowPopup("Not enough money! Need " + (moneyRequired - money) + " more.");
                roomToUnlock = null;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("room_2_entry") || other.CompareTag("room_3_entry") || other.CompareTag("room_4_entry"))
        {
            ShowPopup(""); // Hide message when leaving entry
            roomToUnlock = null;
        }
    }

    public void UnlockRoom() // Make Unlock Button work
    {
        if (roomToUnlock != null && entryToHide != null && money >= moneyRequired)
        {
            money -= moneyRequired;
            roomToUnlock.SetActive(true);
            entryToHide.SetActive(false);
            UpdateMoneyUI();
            ShowPopup(roomToUnlock.name + " Unlocked!");
            Debug.Log(roomToUnlock.name + " Unlocked! Remaining Money: " + money);
        }
        else
        {
            Debug.LogWarning("UnlockRoom() failed: Either roomToUnlock or entryToHide is null!");
        }

        roomToUnlock = null;
        entryToHide = null;
    }

    private void UpdateMoneyUI()
    {
        moneyText.text = "Money: " + money;
    }

    private void ShowPopup(string message)
    {
        popupText.text = message;
        CancelInvoke(nameof(HidePopup));
        Invoke(nameof(HidePopup), 2f);
    }

    private void HidePopup()
    {
        popupText.text = "";
    }
}
