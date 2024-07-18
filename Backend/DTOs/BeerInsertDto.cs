namespace Backend.DTOs
{
    public class BeerInsertDto
    {
        //dto para insertar
        public string? Name { get; set; }
        public int BrandID { get; set; }
        public decimal Alcohol { get; set; }
    }
}
