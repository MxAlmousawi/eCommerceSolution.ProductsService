namespace BuisnessLogicLayer.Dto
{
    public record ProductUpdateRequest
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public CategoryOptions Category { get; set; }
        public double UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
