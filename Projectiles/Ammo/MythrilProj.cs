﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Ammo
{
    public class MythrilProj : AmmoProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 10;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
            ArmorPiercingMult = 1.25f;
        }
    }
}