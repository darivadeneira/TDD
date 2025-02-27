namespace TDDTestingMVC.Models
{
    public class AreaCirculo
    {
        public Double radio { get; set; }
        public double Area()
        {
            return Math.Round(Math.PI * radio * radio, 2);
        }
    }
}
