﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class AltarPillar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("AltarPillar");
        }
    }
}