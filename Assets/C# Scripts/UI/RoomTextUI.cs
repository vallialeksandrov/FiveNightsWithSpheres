using UnityEngine;
using TMPro;

public class RoomTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _roomText;

    private void Start() => UpdateRoomText("Кладовая");

    public void UpdateRoomText(string roomText) => _roomText.text = roomText;
}
