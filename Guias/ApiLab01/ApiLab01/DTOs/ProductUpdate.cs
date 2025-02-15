namespace ApiLab01.DTOs
{
    public class ProductUpdate
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
