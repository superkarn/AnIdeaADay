namespace AIAD.Library.Models
{
    /// <summary>
    /// This is the base class for the application models which has Id property.
    /// Some models do not Id, as they have Composite Keys instead (e.g. ActivityNotification).
    /// These do not inherit from this class.
    /// </summary>
    public abstract class BaseWithIdModel : BaseModel
    {
        public int Id { get; set; }
    }
}
