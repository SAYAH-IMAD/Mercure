using Mercure.Common.Persistence.Model;

namespace Mercure.Patient.Infrastructure.Persistence.Model
{
    public class PatientModel : EntityDB<PatientModel>
    {
        public virtual long?  Id { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName{ get; set; }
        public virtual string Email { get; set; }
        public virtual string Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual IList<ConsultationModel> Consultations { get; set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(PatientModel entity)
        {
            Id = entity.Id;
            LastName = entity.LastName;
            FirstName = entity.FirstName;
            Email = entity.Email;
            PhoneNumber = entity.PhoneNumber;
            Gender = entity.Gender;
            Street = entity.Street;
            City = entity.City;
            PostalCode = entity.PostalCode;

            SynchroniseRelation(Consultations, entity.Consultations);
        }
    }
}
