using Mercure.Common.Persistence.Translator;
using Mercure.Patient.Domain.Aggregate;
using Mercure.Patient.Infrastructure.Persistence.Model;

namespace Mercure.Patient.Infrastructure.Persistence.Translator
{
    internal class ConsultationTranslator : ITranslator<Consultation, ConsultationModel>
    {
        public virtual long? Identifier { get; set; }
        public virtual DateTime Date { get; private set; }

        public ConsultationModel Translate(Consultation aggregate) 
            => new()
            {
                Id = aggregate.Identifier,
                Date = aggregate.Date,
            };

        public Consultation Translate(ConsultationModel persistence) 
            => new(persistence.Id,
                   persistence.Date);
        
    }
}
