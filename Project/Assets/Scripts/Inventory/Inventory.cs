using System.Linq;
using System.Collections.Generic;

public class Inventory
{ 
    public List<Item> items = new List<Item>();
    
    public void AddItem(ItemInfo itemInfo, int amount = 1)
    {
        Item item = items.FirstOrDefault(i => i.itemInfo.id == itemInfo.id);
        if (item != null)
        {
            item.amount++;
        }
        else
        {
            items.Add(new Item() { itemInfo = itemInfo, amount = amount });
        }
    }
    public void RemoveItem(ItemInfo itemInfo)
    {
        Item item = items.FirstOrDefault(i => i.itemInfo.id == itemInfo.id);

        if(item != null)
        {
            item.amount--;
            if(item.amount == 0)
            {
                items.Remove(item);
            }
        }
    }
}

