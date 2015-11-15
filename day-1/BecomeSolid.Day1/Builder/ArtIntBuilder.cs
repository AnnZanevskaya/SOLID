using BecomeSolid.Day1.Entity;

namespace BecomeSolid.Day1.Builder
{
    public class ArtIntBuilder : IMessageBuilder<ArtIntEntity>
    {
        public string Build(ArtIntEntity entity)
        {
            var message = entity.Name;
            return message;
        }
    }
}
