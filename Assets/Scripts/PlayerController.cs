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
    public GameObject room2Entry, room3Entry, room4Entry; // Room entry triggers

    private GameObject roomToUnlock;
    private GameObject entryToHide; // Entry object to hide after unlock

    public Text moneyText;
    public Text popupText;

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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
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
                ShowPopup("Press 'U' to unlock Room 2");
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
                ShowPopup("Press 'U' to unlock Room 3");
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
                ShowPopup("Press 'U' to unlock Room 4");
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

    private void UnlockRoom()
    {
        if (roomToUnlock != null && entryToHide != null && money >= moneyRequired)
        {
            money -= moneyRequired;
            roomToUnlock.SetActive(true);
            entryToHide.SetActive(false); // Hide entry trigger
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
        Invoke(nameof(HidePopup), 2f); // Hide after 2 seconds
    }

    private void HidePopup()
    {
        popupText.text = "";
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnlockRoom();
        }
    }
}
