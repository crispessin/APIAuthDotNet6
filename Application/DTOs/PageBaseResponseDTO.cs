namespace Application.DTOs
{
    public class PageBaseResponseDTO<T>
    {
        public PageBaseResponseDTO(int totalRegisters, List<T> data)
        {
            TotalRegsiters = totalRegisters;
            Data = data;
        }

        public int TotalRegsiters { get; private set; }
        public List<T> Data { get; private set; }
    }
}
