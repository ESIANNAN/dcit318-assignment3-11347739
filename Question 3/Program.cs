class Program
{
    static void Main()
    {
        WareHouseManager manager = new WareHouseManager();

        manager.SeedData();
        manager.PrintAllItems(manager._groceries);
        manager.PrintAllItems(manager._electronics);

        // Test exceptions
        try
        {
            manager._electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Duplicate add test: {ex.Message}");
        }

        manager.RemoveItemById(manager._groceries, 99);

        try
        {
            manager._groceries.UpdateQuantity(1, -10);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid quantity test: {ex.Message}");
        }

        manager.IncreaseStock(manager._electronics, 2, 5);
    }
}
