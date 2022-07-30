namespace CoffeeShopSystem.Constant
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Cashier = "Cashier";

        public enum Status
        {
            Pending, Approved, Processing, Delivered, Cancelled
        };
    }
}
