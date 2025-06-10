using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    private ItemData equipItemSO;
    [SerializeField] EquipType slotType;

    [Header("UI")]
    [SerializeField] Image icon;
    [SerializeField] GameObject popUpUI;
    [SerializeField] 
    private Button slotBtn;

    void Awake()
    {
        slotBtn = GetComponent<Button>();
        icon = GetComponentInChildren<Image>();
        icon.enabled = false;
    }

    public void Equip(ItemData itemData)
    {
        if (itemData == null) return;

        equipItemSO = itemData;
        icon.sprite = equipItemSO.itemIcon;
        icon.enabled = true;

        slotBtn.onClick.AddListener(OpenDescription);
    }

    public void UnEquip()
    {
        equipItemSO = null;
        icon.enabled = false;
    }

    private void OpenDescription()
    {

    }
}
