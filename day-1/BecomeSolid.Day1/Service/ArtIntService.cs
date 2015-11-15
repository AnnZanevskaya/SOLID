using BecomeSolid.Day1.Commands;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Helpers;

namespace BecomeSolid.Day1.Service
{
    public class ArtIntService : IService<ArtIntEntity>
    {
        private readonly ArtIntCommandsDictionary dictionary;
        public ArtIntService(ArtIntCommandsDictionary dictionary)
        {
            this.dictionary = dictionary;
        }
        public ArtIntEntity GetInformation(string keyForInformathion)
        {
            keyForInformathion = keyForInformathion.GetWordsExeptFirst();
            string response = dictionary.GetAswerOrDefault(keyForInformathion);
            return new ArtIntEntity()
            {
                Name = response
            };
        }
    }
}
