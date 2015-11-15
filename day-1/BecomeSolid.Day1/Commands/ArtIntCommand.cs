using BecomeSolid.Day1.BotContainer;
using BecomeSolid.Day1.Builder;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Service;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class ArtIntCommand<T> : ICommand where T:IEntity
    {
        private readonly Api api;
        private readonly IMessageBuilder<T> builder;
        private readonly IService<T> service; 
        public ArtIntCommand(IBotContainer bot, IMessageBuilder<T> builder, IService<T> service)
        {
            this.builder = builder;
            api = bot.BotApi;
            this.service = service;
        }
        public async void Execute(Update context)
        {
            T artIntInfo = service.GetInformation(context.Message.Text);
            string response = builder.Build(artIntInfo);

            var t = await api.SendTextMessage(context.Message.Chat.Id, response);
        }
    }
}
