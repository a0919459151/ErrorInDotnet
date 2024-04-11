namespace Backend.Contracts.Activity;

public class GetActivitiesRequestDto
{
    public ActivityType ActivityType { get; set; }
}

public class GetActivitiesResponseDto
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public ActivityType ActivityType { get; set; }
}