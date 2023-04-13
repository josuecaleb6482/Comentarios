namespace ApiComentarios.Entities.DTOs
{
    public class PaginacionDTO
    {
        private const int maxSizePage = 50;

        public int pageNumber { get; set; } = 1;

        private int _maxItemsPage = 10;

        public int maxItemsPage
        {
            get => _maxItemsPage;
            set => _maxItemsPage = (value > maxItemsPage) ? maxItemsPage : value;
        }
    }
}