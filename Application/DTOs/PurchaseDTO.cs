namespace Application.DTOs
{
    public class PurchaseDTO
    {
        private int productId;
        private int personId;

        public PurchaseDTO(int productId, int personId)
        {
            this.productId = productId;
            this.personId = personId;
        }

        public int Id { get; set; }
        public string CodErp { get; set; }
        public string Document { get; set; }
    }
}
