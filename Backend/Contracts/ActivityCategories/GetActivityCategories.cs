namespace Backend.Contracts.ActivityCategories;

public class GetActivityCategoriesRequestDto
{

}

public class GetActivityCategoriesResponseDto
{
    // Id
    public int Id { get; set; }

    // CategoryName
    public required string CategoryName { get; set; }
}