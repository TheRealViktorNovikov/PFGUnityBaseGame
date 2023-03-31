using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorText : MonoBehaviour, IDataPersistence
{
    private int doorCount = 0;
    public Text doorCountText;

    // Update is called once per frame
    public void DoorOpened()
    {
        doorCount++;
        doorCountText = GameObject.Find("Text Count").GetComponent<Text>();
        doorCountText.text = doorCount.ToString();
    }

    public void LoadData(GameData data)
    {
        this.doorCount = data.doorCountSaved;
    }

    public void SaveData(GameData data)
    {
        data.doorCountSaved = this.doorCount;
    }
}
