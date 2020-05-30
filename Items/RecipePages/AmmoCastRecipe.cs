﻿using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VampKnives.Items.RecipePages
{
    public class AmmoCastRecipe : RecipeItem
    {
        bool FirstUse;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ammo Cast Recipe");
            Tooltip.SetDefault("Right-click to open");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line3 = new TooltipLine(mod, "Face", "Recipe:");
            line3.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line3);
            TooltipLine line4 = new TooltipLine(mod, "Face", "-Hammer");
            line4.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line4);
            TooltipLine line5 = new TooltipLine(mod, "Face", "-5 Iron Bars");
            line5.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line5);
            TooltipLine line6 = new TooltipLine(mod, "Face", "-Stone Ammo Sculpt");
            line6.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line6);
        }
        public override void HoldItem(Player player)
        {
            VampKnives.IsAmmoRecipe = true;
            VampKnives.IsKnifeRecipe = false;
            VampKnives.IsSharpeningRodRecipe = false;
            VampKnives.IsPlateRecipe = false;
            VampKnives.IsAmmoSculptRecipe = false;
            VampKnives.IsKnifeSculptRecipe = false;
            VampKnives.IsSharpeningSculptRecipe = false;
        }
    }
}