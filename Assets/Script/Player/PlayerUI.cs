using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void UpdateText(string newMessage)
    {
        text.text = newMessage;
    }
}
