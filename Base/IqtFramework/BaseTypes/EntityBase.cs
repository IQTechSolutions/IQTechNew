using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts;

namespace IqtFramework.BaseTypes
{
    public abstract class EntityBase
    {
        #region Constructors
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            SetCreation();
        }

        protected EntityBase(EntityBase baseEntity)
        {
            Id = baseEntity.Id;
            SetCreation();
        }

        #endregion

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, DisplayName("Id"), Column("Id")]
        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None), Column("DisplayIndex")]
        public int? DisplayIndex { get; set; }

        #endregion

        #region Creation/Modification Members

        [DisplayName("Created By:")] public string CreatedBy { get; set; } = "";

        [DisplayName("Created On:")] public DateTime Created { get; set; }

        [DisplayName("Created On:")]
        public DateTime CreatedLocalTime
        {
            get { return Created.ToLocalTime(); }
        }

        [DisplayName("Modified By:")] public string? ModifiedBy { get; set; }

        [DisplayName("Modified On:")] public DateTime? Modified { get; set; }

        public string CreatedDateString
        {
            get
            {
                return GetDateString(Created.ToLocalTime());
            }
        }

        public string ModifiedDateString
        {
            get
            {
                if (Modified != null)
                {
                    return GetDateString(Modified.Value.ToLocalTime());
                }
                else return "";
            }
        }

        #region Methods

        public string GetDateString(DateTime dateTime)
        {
            if (dateTime.Date.Day == DateTime.Now.Day)
            {
                return "Today " + dateTime.ToLongDateString();
            }
            else if (dateTime.Date.AddDays(-1).Day == DateTime.Now.Day)
            {
                return "Yesterday " + dateTime.ToLongDateString();
            }
            return dateTime.ToLongDateString();
        }

        public string IdentityCreatingOrModifying(string? identity)
        {
            return string.IsNullOrEmpty(identity) ? "Unknown User" : identity;
        }

        public void SetCreation(string? identity = null)
        {
            CreatedBy = IdentityCreatingOrModifying(identity);
            Created = DateTime.Now.ToUniversalTime();
        }

        public void SetModification(string? identity = null)
        {
            ModifiedBy = IdentityCreatingOrModifying(identity);
            Modified = DateTime.Now.ToUniversalTime();
        }

        public void SetIdentity(string? identity = null)
        {
            Id = string.IsNullOrEmpty(identity) ? Guid.NewGuid().ToString() : identity;
        }

        #endregion

        #endregion
    }
}