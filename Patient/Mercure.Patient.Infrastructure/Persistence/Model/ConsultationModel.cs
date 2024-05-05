using Mercure.Common.Persistence.Model;

namespace Mercure.Patient.Infrastructure.Persistence.Model
{
    public class ConsultationModel : EntityDB<ConsultationModel>
    {
        public virtual long? Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime CreationDate { get; set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(ConsultationModel entity)
        {
            Id = entity.Id;
            Date = entity.Date;
            CreationDate = entity.CreationDate;
        }
    }
}
