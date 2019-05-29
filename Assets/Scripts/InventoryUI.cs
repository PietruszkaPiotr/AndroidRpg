using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject inventoryButton;
    public GameObject attackButton;
    public GameObject[] spellButton;
    public GameObject[] infoButton;
    public GameObject equipmentUI;
    public GameObject HealthPot;
    public GameObject ManaPot;
    public GameObject HealthBar;
    public GameObject ManaBar;
    public GameObject ExpBar;
    public GameObject StatsUI;
    public GameObject TreeUI;
    public GameObject SpellBookUI;
    Inventory inventory;
    EquipmentManager equipment;
    InventorySlot[] slots;
    EqtSlot[] eqSlots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    void UpdateUI()
    {
       for(int i = 0; i< slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void UpdateEq()
    {
        
    }
    public void HideInventory()
    {
        Invoke("Hide", .1f);
    }

    public void ShowInventory()
    {
        for(int i=0;i<4;i++) {
            spellButton[i].SetActive(false);
        }
        for (int i = 0; i < 4; i++) {
            infoButton[i].SetActive(true);
        }
        inventoryUI.SetActive(true);
        equipmentUI.SetActive(true);
        attackButton.SetActive(false);
        HealthPot.SetActive(false);
        ManaPot.SetActive(false);
        HealthBar.SetActive(false);
        ManaBar.SetActive(false);
        ExpBar.SetActive(false);
        StatsUI.SetActive(false);
        TreeUI.SetActive(false);
        SpellBookUI.SetActive(false);
    }
    void Hide()
    {
        for (int i = 0; i < 4; i++) {
            spellButton[i].SetActive(true);
        }
        for (int i = 0; i < 4; i++) {
            infoButton[i].SetActive(false);
        }
        inventoryUI.SetActive(false);
        attackButton.SetActive(true);
        equipmentUI.SetActive(false);
        StatsUI.SetActive(false);
        HealthPot.SetActive(true);
        ManaPot.SetActive(true);
        HealthBar.SetActive(true);
        ManaBar.SetActive(true);
        ExpBar.SetActive(true);
        TreeUI.SetActive(false);
        SpellBookUI.SetActive(false);
    }
    public void ShowStats()
    {
        inventoryUI.SetActive(false);
        equipmentUI.SetActive(false);
        StatsUI.SetActive(true);
        TreeUI.SetActive(false);
        SpellBookUI.SetActive(false);
    }

    public void ShowTree()
    {
        inventoryUI.SetActive(false);
        equipmentUI.SetActive(false);
        StatsUI.SetActive(false);
        TreeUI.SetActive(true);
        SpellBookUI.SetActive(false);
    }
    public void ShowBook()
    {
        inventoryUI.SetActive(false);
        equipmentUI.SetActive(false);
        StatsUI.SetActive(false);
        TreeUI.SetActive(false);
        SpellBookUI.SetActive(true);
    }
}
