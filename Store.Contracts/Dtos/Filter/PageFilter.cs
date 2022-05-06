
namespace Store.Contracts.Dtos
{
    public class PageFilter 
    {
        public int page { get; set; } =1;
        public int limit { get; set; } = 5;
        public string keySearch { get; set; } = null;
    }
}
