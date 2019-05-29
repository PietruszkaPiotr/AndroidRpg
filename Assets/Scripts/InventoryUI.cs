using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject inventoryButton;
    public GameObject attackButton;
    public GameObject[] spellButton;
    public GameObject equipmentUI;
    public GameObject HealthPot;
    public GameObject ManaPot;
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

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }*/
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
        inventoryUI.SetActive(true);
        equipmentUI.SetActive(true);
        attackButton.SetActive(false);
        HealthPot.SetActive(false);
        ManaPot.SetActive(false);
    }
    void Hide()
    {
        for (int i = 0; i < 4; i++) {
            spellButton[i].SetActive(true);
        }
        inventoryUI.SetActive(false);
        attackButton.SetActive(true);
        equipmentUI.SetActive(false);
        HealthPot.SetActive(true);
        ManaPot.SetActive(true);
    }
}
