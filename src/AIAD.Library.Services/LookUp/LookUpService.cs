using AIAD.Library.Models;
using AIAD.Library.Models.LookUp;
using AIAD.Library.Services.Interfaces;
using System.Collections.Generic;

namespace AIAD.Library.Services
{
    public class LookUpService : ILookUpService
    {
        public LookUpService()
        { }

        public IDictionary<string, IEnumerable<BaseLookUpModel>> GetAll(ApplicationContext context)
        {
            return new Dictionary<string, IEnumerable<BaseLookUpModel>>
            {
                { "IdeaPrivacies", IdeaPrivacy.GetValues() },
            };
        }
    }
}
