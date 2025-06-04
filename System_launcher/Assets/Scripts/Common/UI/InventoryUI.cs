using Gpm.Ui;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum InventorySortType
{
    ItemGrade,
    ItemType,
}

public class InventoryUI : BaseUI
{
    public EquippedItemSlot WeaponSlot;
    public EquippedItemSlot ShieldSlot;
    public EquippedItemSlot ChestArmorSlot;
    public EquippedItemSlot BootsSlot;
    public EquippedItemSlot GlovesSlot;
    public EquippedItemSlot AccessorySlot;

    public InfiniteScroll InventoryScrollList;
    public TextMeshProUGUI SortBtnTxt;

    private InventorySortType m_InventorySortType = InventorySortType.ItemGrade;

    public override void SetInfo(BaseUIData uiData)
    {
        base.SetInfo(uiData);

        SetEquippedItems();
        SetInventory();
        SortInventory();
    }

    private void SetEquippedItems()
    {
        var userInventoryData = UserDataManager.Instance.GetUserData<UserInventoryData>();
        if (userInventoryData == null)
        {
            Logger.LogError("UserInventoryData does not exist.");
            return;
        }

        if (userInventoryData.EquippedWeaponData != null)
        {
            WeaponSlot.SetItem(userInventoryData.EquippedWeaponData);
        }
        else
        {
            WeaponSlot.ClearItem();
        }

        if (userInventoryData.EquippedShieldData != null)
        {
            ShieldSlot.SetItem(userInventoryData.EquippedShieldData);
        }
        else
        {
            ShieldSlot.ClearItem();
        }

        if (userInventoryData.EquippedChestArmorData != null)
        {
            ChestArmorSlot.SetItem(userInventoryData.EquippedChestArmorData);
        }
        else
        {
            ChestArmorSlot.ClearItem();
        }

        if (userInventoryData.EquippedBootsData != null)
        {
            BootsSlot.SetItem(userInventoryData.EquippedBootsData);
        }
        else
        {
            BootsSlot.ClearItem();
        }

        if (userInventoryData.EquippedGlovesData != null)
        {
            GlovesSlot.SetItem(userInventoryData.EquippedGlovesData);
        }
        else
        {
            GlovesSlot.ClearItem();
        }

        if (userInventoryData.EquippedAccessoryData != null)
        {
            AccessorySlot.SetItem(userInventoryData.EquippedAccessoryData);
        }
        else
        {
            AccessorySlot.ClearItem();
        }
    }

    private void SetInventory()
    {
        InventoryScrollList.Clear();

        var userInventoryData = UserDataManager.Instance.GetUserData<UserInventoryData>();
        if (userInventoryData != null)
        {
            foreach (var itemData in userInventoryData.InventoryItemDataList)
            {
                var itemSlotData = new InventoryItemSlotData();
                itemSlotData.SerialNumber = itemData.SerialNumber;
                itemSlotData.ItemId = itemData.ItemId;
                InventoryScrollList.InsertData(itemSlotData);
            }
        }
    }

    private void SortInventory()
    {
        switch (m_InventorySortType)
        {
            case InventorySortType.ItemGrade:
                SortBtnTxt.text = "GRADE";

                InventoryScrollList.SortDataList((a, b) =>
                {
                    var itemA = a.data as InventoryItemSlotData;
                    var itemB = b.data as InventoryItemSlotData;

                    //sort by item grade
                    int compareResult = ((itemB.ItemId / 1000) % 10).CompareTo((itemA.ItemId / 1000) % 10);

                    //if same item grade, sort by item type
                    if (compareResult == 0)
                    {
                        var itemAIdStr = itemA.ItemId.ToString();
                        var itemAComp = itemAIdStr.Substring(0, 1) + itemAIdStr.Substring(2, 3); //11001 -> 1001

                        var itemBIdStr = itemB.ItemId.ToString();
                        var itemBComp = itemBIdStr.Substring(0, 1) + itemBIdStr.Substring(2, 3); //11001 -> 1001

                        compareResult = itemAComp.CompareTo(itemBComp);
                    }

                    return compareResult;
                });
                break;
            case InventorySortType.ItemType:
                SortBtnTxt.text = "TYPE";
                InventoryScrollList.SortDataList((a, b) =>
                {
                    var itemA = a.data as InventoryItemSlotData;
                    var itemB = b.data as InventoryItemSlotData;

                    //sort by item type
                    var itemAIdStr = itemA.ItemId.ToString();
                    var itemAComp = itemAIdStr.Substring(0, 1) + itemAIdStr.Substring(2, 3); //11001 -> 1001

                    var itemBIdStr = itemB.ItemId.ToString();
                    var itemBComp = itemBIdStr.Substring(0, 1) + itemBIdStr.Substring(2, 3); //11001 -> 1001

                    int compareResult = itemAComp.CompareTo(itemBComp);

                    //if same item type, sort by item grade
                    if (compareResult == 0)
                    {
                        compareResult = ((itemB.ItemId / 1000) % 10).CompareTo((itemA.ItemId / 1000) % 10);
                    }

                    return compareResult;
                });
                break;
            default:
                break;
        }
    }

    public void OnClickSortBtn()
    {
        switch (m_InventorySortType)
        {
            case InventorySortType.ItemGrade:
                m_InventorySortType = InventorySortType.ItemType;
                break;
            case InventorySortType.ItemType:
                m_InventorySortType = InventorySortType.ItemGrade;
                break;
            default:
                break;
        }

        SortInventory();
    }
}
