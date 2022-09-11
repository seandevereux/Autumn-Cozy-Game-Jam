using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int stackSize = 0;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TextMeshProUGUI _label;
    [SerializeField]
    private GameObject _stackObj;
    [SerializeField]
    private TextMeshProUGUI _stackLabel;

    public void Set(InventoryItem item)
    {
        _icon.sprite = item.data.icon;
        _label.text = item.data.itemName;
        if(item.stackSize < 1)
        {
            _stackObj.SetActive(false);
            return;
        }
        _stackLabel.text = item.stackSize.ToString();
    }

    public void Select()
    {
        _icon.color = Color.red;
    }
}
