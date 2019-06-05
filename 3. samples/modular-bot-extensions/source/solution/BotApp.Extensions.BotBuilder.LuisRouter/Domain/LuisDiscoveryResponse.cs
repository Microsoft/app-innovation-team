﻿using System.Collections.Generic;

namespace BotApp.Extensions.BotBuilder.LuisRouter.Domain
{
    public class LuisDiscoveryResponseResult
    {
        public bool IsSucceded { get; set; }
        public int ResultId { get; set; }
        public List<LuisAppDetail> LuisAppDetails { get; set; } = new List<LuisAppDetail>();
    }
}