using UnityEngine;
using UnityEngine.UI;

public class EqtSlot : MonoBehaviour
{
    public Image icon;
    Item item;
    private void Start()
    {
        item = null;
        ClearSlot();
    }
    public void AddItem(Equipment newItem)
    {
        
        item = newItem;
        if(item.isDefaultItem==false)
        {
            icon.sprite = item.icon;
        }
        else
        {
            icon.sprite = null;
        }
        
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
