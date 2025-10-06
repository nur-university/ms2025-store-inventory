namespace Inventory.Domain.Items;

internal class AverageCostStrategy : ICostStrategy
{
    public decimal CalculateNewCost(int currentStock, decimal currentUnitaryCost, 
        int newStockToAdd, decimal newUnitaryCost)
    {
        int totalStock = currentStock + newStockToAdd;
        decimal newCost = Math.Round(
            (currentUnitaryCost * currentStock + 
                newUnitaryCost * newStockToAdd) / totalStock, 2);
        return newCost;
    }
}
