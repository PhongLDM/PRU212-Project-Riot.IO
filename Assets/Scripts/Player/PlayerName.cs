using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text nameText;

    void Start()
    {
        nameText.text = MainMenu.playerName;
    }
}
