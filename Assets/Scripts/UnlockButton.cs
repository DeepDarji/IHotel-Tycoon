using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    public RoomUnlocker roomUnlocker;

    public void UnlockWithButton()
    {
        roomUnlocker.UnlockRoom();
    }
}
