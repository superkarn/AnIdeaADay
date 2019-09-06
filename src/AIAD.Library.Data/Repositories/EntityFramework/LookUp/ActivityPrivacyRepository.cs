using AIAD.Library.Data.Data;
using AIAD.Library.Models.LookUp;

namespace AIAD.Library.Data.Repositories.EntityFramework.LookUp
{
    public class IdeaPrivacyRepository : BaseLookUpRepository<IdeaPrivacy>
    {
        public IdeaPrivacyRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
