
public class PlaceSellController
{
    private int basePlantCost;

    public PlaceSellController(int basePlantCost)
    {
        this.basePlantCost = basePlantCost;
    }

    public long SellPlant()
    {
        return basePlantCost * PlantManager.Instance.GetPlantCostType();
    }

}
