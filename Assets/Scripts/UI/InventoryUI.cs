using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private UIManager uIManager;
    private Player player;

    [SerializeField] GameObject itemSlotPrefab;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public void Init(UIManager uIManager)
    {
        this.uIManager = uIManager;
    }

    public void EquipItem()
    {

    }

    public void UnEquipItem()
    {

    }
}
