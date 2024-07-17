namespace BackendPieProject.Dtos
{
    public class CategoryReadDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class CategoryCreateDTO
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class CategoryUpdateDTO
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
