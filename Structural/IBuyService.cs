namespace designPatterns.Structural
{
    public interface IBuyService
    {
        
        void ReloadData();
        string BuyClothes(string id);
        string GetPrices();
       bool isloaded { get; set; }
    }
}