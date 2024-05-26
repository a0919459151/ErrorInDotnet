namespace CMS.Contracts.Activiy;

public class GetActivityListViewModel
{
    public List<ActivityModel> Activities { get; set; } = new();

}

public class ActivityModel
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public ActivityType ActivityType { get; set; }
}