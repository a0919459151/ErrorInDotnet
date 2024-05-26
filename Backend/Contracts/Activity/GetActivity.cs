namespace Backend.Contracts.Activity;

public class GetActivityResponseDto
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public ActivityType ActivityType { get; set; }
}
