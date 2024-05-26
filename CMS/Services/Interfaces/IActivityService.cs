using CMS.Contracts.Activiy;

namespace CMS;

public interface IActivityService
{
    // GetActivityPageList
    Task<Result> GetActivityPageList(GetActivityPageListQueryModel query);

    // GetActivityList
    Task<Result> GetActivityList();

    // GetActivity
    Task<Result> GetActivity(int id);

    // CreateOrUpdateActivity
    Task<Result> CreateOrUpdateActivity(CreateOrUpdateActivityViewModel vm);

    // DeleteActivity
    Task<Result> DeleteActivity(int id);
}