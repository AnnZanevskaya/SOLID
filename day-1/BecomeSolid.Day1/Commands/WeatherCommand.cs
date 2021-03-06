﻿using System;
using BecomeSolid.Day1.BotContainer;
using BecomeSolid.Day1.Builder;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Service;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class WeatherCommand<T>  : ICommand where T:IEntity
    {
        private readonly Api api;
        private readonly IService<T> service;
        private readonly IMessageBuilder<T> builder;

        public WeatherCommand(IBotContainer bot, IService<T> service, IMessageBuilder<T> builder)
        {
            this.builder = builder;
            this.service = service;
            this.api = bot.BotApi;
        }
        public async void Execute(Update context)
        {
            T weatherInfo = service.GetInformation(context.Message.Text);

            string response = builder.Build(weatherInfo);

            var t = await api.SendTextMessage(context.Message.Chat.Id, response);
            Console.WriteLine("Echo Message: {0}", response);
        }

    }
}
