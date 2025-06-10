using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private ItemData itemSO;

    [Header("UI")]
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI equipText;
    [SerializeField] TextMeshProUGUI countText;
    private Button slotBtn;

    private int itemCount = 0;

    /// <summary>
    /// 장비 아이템 초기 세팅
    /// </summary>
    /// <param name="itemData"></param>
    public void SetSlot(ItemData itemData)
    {
        if (itemData == null) return;

        itemSO = itemData;
        countText.enabled = false;
        equipText.enabled = false;
        icon.sprite = itemSO.itemIcon;

        if (TryGetComponent(out slotBtn))
        {
            slotBtn.onClick.AddListener(OpenDescription);
        }
    }

    /// <summary>
    /// 소모품 아이템 초기 세팅
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="itemCount"></param>
    public void SetSlot(ItemData itemData, int itemCount)
    {
        if (itemData == null) return;

        itemSO = itemData;

        if (itemSO.isConsumable)
        {
            equipText.enabled = false;

            this.itemCount = itemCount;
            countText.text = itemCount.ToString();
        }
    }

    /// <summary>
    /// 기존 아이템에 개수 추가
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="itemCount"></param>
    public void AddItem(ItemData itemData, int itemCount)
    {
        if (itemSO != itemData) return;

        this.itemCount += itemCount;
        countText.text = itemCount.ToString();
    }

    private void OpenDescription()
    {

    }
}
