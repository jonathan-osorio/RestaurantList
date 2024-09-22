namespace RestaurantList.Models
{
    public class Restaurant
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<RestaurantDish>? RestaurantDishes { get; set; }
    }
}
