using ChangeTracking;
using System.ComponentModel;

namespace Mercure.Common.Persistence
{
    public abstract class EntityDB<T> : IEntityDB where T : EntityDB<T>
    {
        public abstract string Identifier { get; }

        public abstract void Synchronise(T entity);

        public void SynchroniseRelation<TChild>(IList<TChild> original, IList<TChild> updated) where TChild : EntityDB<TChild>
        {
            IList<TChild> tracked = original.AsTrackable();

            foreach (TChild child in tracked)
            {
                if (!updated.Any(e => e.Identifier == child.Identifier))
                    tracked.Remove(child);
            }

            List<TChild> added = new();

            foreach (TChild child in updated)
            {
                if (tracked.Any(e => e.Identifier == child.Identifier))
                    tracked.Single(e => e.Identifier == child.Identifier).Synchronise(child);
                else
                    added.Add(child);
            }

            added.ForEach(e => tracked.Add(e));
        }
    }
}
