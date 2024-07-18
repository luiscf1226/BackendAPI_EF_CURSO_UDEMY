namespace Backend.DTOs
{
    public class BeerDto
    {
        //mostrar solo lo necesario
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        public decimal Alcohol { get; set; }
    }
}
