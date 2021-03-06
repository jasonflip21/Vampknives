﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Items.Materials;

namespace VampKnives.Items
{
    public class BloodAltarItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Altar");
            Tooltip.SetDefault("An altar to perform rituals at");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 16;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("BloodAltar");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 40);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ModContent.ItemType<StableCrimsonCrystal>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 40);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ModContent.ItemType<StableCrimsonCrystal>(), 4);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}