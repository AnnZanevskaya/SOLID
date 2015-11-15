using BecomeSolid.Day1.Entity;

namespace BecomeSolid.Day1.Builder
{
    public interface IMessageBuilder<T> where T:IEntity
    {
        string Build(T entity);
    }
}
