namespace Backend.Contracts.ActivityCategories;

public class GetActivityCategoryResponseDto
{
    // Id
    public int Id { get; set; }

    // CategoryName
    public required string CategoryName { get; set; }
}