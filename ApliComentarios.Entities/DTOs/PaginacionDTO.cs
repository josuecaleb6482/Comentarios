namespace ApiComentarios.Entities.DTOs
{
    public class PaginacionDTO
    {
        private const int maxSizePage = 50;
        /// <summary>
        /// número de página
        /// </summary>
        public int pageNumber { get; set; } = 1;
        /// <summary>
        /// maxímo de paginas que desea mostrar
        /// </summary>
        private int _maxItemsPage = 10;

        public int maxItemsPage
        {
            get => _maxItemsPage;
            set => _maxItemsPage = (value > maxItemsPage) ? maxItemsPage : value;
        }
    }
}