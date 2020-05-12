﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Accessories
{
    public class Whetstone : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Whetstone");
            Tooltip.SetDefault("2,000 grit stone and 5,000 grit stone"
                + "\nput together in one brick"
                + "\n20% increased knife damage");
        }

        public override void SafeSetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = 2;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            KnifeDamagePlayer modPlayer = KnifeDamagePlayer.ModPlayer(player);
            modPlayer.knifeDamageMult += 0.2f;
            crafted = true;
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "Requires a Chisel and Hammer to craft");
            line.overrideColor = new Color(86, 86, 86);
            if (crafted == false)
                tooltips.Add(line);
        }
        public override void OnCraft(Recipe recipe)
        {
            crafted = true;
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
        public override void AddRecipes()
        {
            HammerAndChiselRecipe recipe = new HammerAndChiselRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 20);
            recipe.AddIngredient(ItemID.SandBlock, 20);
            recipe.AddIngredient(ItemID.Granite, 20);
            recipe.AddIngredient(ItemID.Marble, 20);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new HammerAndChiselRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 10);
            recipe.AddIngredient(ItemID.SandBlock, 10);
            recipe.AddIngredient(ItemID.Granite, 10);
            recipe.AddIngredient(ItemID.Marble, 10);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
