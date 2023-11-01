namespace Mercure.Common.Persistence
{
    public abstract class EntityDB<T> : IEntityDB where T : EntityDB<T>
    {
        public abstract string Identifier { get; }

        public abstract void Synchronise(T entity);

        public void SynchroniseRelation<TChild>(IList<TChild> original, IList<TChild> updated) where TChild : EntityDB<TChild>
        {
            foreach (TChild child in original)
            {
                if (!updated.Any(e => e.Identifier == child.Identifier))
                    original.Remove(child);
            }

            List<TChild> added = new();

            foreach (TChild child in updated)
            {
                if (original.Any(e => e.Identifier == child.Identifier))
                    original.Single(e => e.Identifier == child.Identifier).Synchronise(child);
                else
                    added.Add(child);
            }

            added.ForEach(e => original.Add(e));
        }
    }
}
