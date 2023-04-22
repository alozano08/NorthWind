namespace NorthWind.UseCasesDTOs.CreateOrder
{
    public class CreateOrderParams
    {
        public string CustomerId { get; set; }
        public string ShipAdress{ get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetailParams> OderDetails { get; set; }
    }
}