using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.UI;
using Terraria.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using VampKnives.Projectiles;

namespace VampKnives
{
    public class VampKnives : Mod
    {
        internal static VampKnives instance;
        public static ModHotKey HoodUpDownHotkey;
        public static ModHotKey SupportHotKey;
        public static ModHotKey VampDashHotKey;
        public static ModHotKey SupportArmorHotKey;
        public static int inventoryIndex;
        public UserInterface customRecources;
        public UserInterface customResources2;
        public UserInterface FirstLoadUI;
        private VampBar vampBar;
        private RecipePageState RecipePage;
        private EntranceDamageSettingsPanel FirstLoadUIPanel;
        private WarningMessage warning;
        //private UserInterface WarningMessage;
        internal UserInterface WarningMessagePerson;
        internal UserInterface VampireUserInterface;
        internal UserInterface VampireUserInterface2;
        public static bool IsAmmoRecipe;
        public static bool IsKnifeRecipe;
        public static bool IsSharpeningRodRecipe;
        public static bool IsPlateRecipe;
        public static bool IsAmmoSculptRecipe;
        public static bool IsKnifeSculptRecipe;
        public static bool IsSharpeningSculptRecipe;
        public static bool ChosenDifficulty;
        public static bool Legacy;
        public static bool Normal = true;
        public static bool Unforgiving;
        public static bool ChangeItemIsHeld;
        public static bool HammerInSlot;
        public static bool ChiselInSlot;
        public UserInterface WorkbenchSlots;
        private WorkbenchSlotState WorkbenchSlotPanel;
        public UserInterface UpgradePanelUI;
        private UpgradePanel UpgradePanelState;
        internal UserInterface BloodAltarUIPanel;
        private BloodAltarUI BloodAltarUIState;
        bool MarkForDeletion;

        //public static List<int> BloodAltarPosition = new List<int>();

        public static int SharpnessUpgradeCounter;
        public static int CritUpgradeCounter;
        public static int SpecialUpgradeCounter;
        bool Error;
        string ErrorMessage;
        int ErrorTimer;
        //public static ModPacket MyPacket;
        //public static int MyPacketIdentifier;
        //private UserInterface VampBarInterface;
        //public VampBar vampbar;
        //private VampResource VampResource;

        public VampKnives()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            ModRecipe recipe2 = new ModRecipe(this);
            ModRecipe recipe3 = new ModRecipe(this);
            ModRecipe recipe4 = new ModRecipe(this);
            ModRecipe recipe5 = new ModRecipe(this);
            ModRecipe recipe6 = new ModRecipe(this);
            ModRecipe recipe7 = new ModRecipe(this);
            ModRecipe recipe8 = new ModRecipe(this);
            ModRecipe recipe9 = new ModRecipe(this);
            ModRecipe recipe10 = new ModRecipe(this);
            ModRecipe recipe11 = new ModRecipe(this);
            recipe.AddIngredient(this.GetItem("IronKnives"), 1);
            recipe.AddIngredient(ItemID.CrimsonKey, 1);
            recipe.AddTile(this.GetTile("KnifeBench"));
            recipe.SetResult(ItemID.VampireKnives);
            recipe.AddRecipe();
            recipe2.AddIngredient(this.GetItem("WeakVampireKnives"), 1);
            recipe2.AddIngredient(this.GetItem("LivingTissue"), 1);
            recipe2.AddTile(this.GetTile("KnifeBench"));
            recipe2.SetResult(ItemID.VampireKnives);
            recipe2.AddRecipe();
            recipe3.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe3.AddIngredient(ItemID.BottledWater, 1);
            recipe3.AddTile(TileID.AlchemyTable);
            recipe3.SetResult(ItemID.LesserManaPotion);
            recipe3.AddRecipe();
            recipe4.AddIngredient(this.GetItem("Chisel"), 1);
            recipe4.AddTile(TileID.Furnaces);
            recipe4.SetResult(ItemID.IronBar);
            recipe4.AddRecipe();
            recipe5.AddIngredient(this.GetItem("Hammer"), 1);
            recipe5.AddTile(TileID.Furnaces);
            recipe5.SetResult(ItemID.IronBar, 1);
            recipe5.AddRecipe();
            recipe6.AddIngredient(this.GetItem("DartCast"));
            recipe6.AddTile(TileID.Furnaces);
            recipe6.SetResult(ItemID.IronBar, 3);
            recipe6.AddRecipe();
            recipe7.AddIngredient(this.GetItem("IronKnivesMold"));
            recipe7.AddTile(TileID.Furnaces);
            recipe7.SetResult(ItemID.IronBar, 3);
            recipe7.AddRecipe();
            recipe8.AddIngredient(this.GetItem("Chisel"), 1);
            recipe8.AddTile(TileID.Furnaces);
            recipe8.SetResult(ItemID.LeadBar);
            recipe8.AddRecipe();
            recipe9.AddIngredient(this.GetItem("Hammer"), 1);
            recipe9.AddTile(TileID.Furnaces);
            recipe9.SetResult(ItemID.LeadBar, 1);
            recipe9.AddRecipe();
            recipe10.AddIngredient(this.GetItem("DartCast"));
            recipe10.AddTile(TileID.Furnaces);
            recipe10.SetResult(ItemID.LeadBar, 3);
            recipe10.AddRecipe();
            recipe11.AddIngredient(this.GetItem("IronKnivesMold"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.LeadBar, 3);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(this.GetItem("SharpeningRodCast"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.LeadBar, 3);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(this.GetItem("SharpeningRodCast"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.IronBar, 3);
            recipe11.AddRecipe();
            //LIVINGFIREBLOCK
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(ItemID.HellstoneBrick, 5);
            recipe11.AddIngredient(ItemID.Fireblossom);
            recipe11.needLava = true;
            recipe11.SetResult(ItemID.LivingFireBlock, 5);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(ItemID.HellstoneBrick, 25);
            recipe11.AddIngredient(ItemID.Fireblossom, 5);
            recipe11.AddTile(TileID.Hellforge);
            recipe11.SetResult(ItemID.LivingFireBlock, 5);
            recipe11.AddRecipe();

            HammerRecipe HammerConvertRecipe = new HammerRecipe(this);
            //Sand
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 6);
            HammerConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            HammerConvertRecipe.SetResult(ItemID.SandBlock, 5);
            HammerConvertRecipe.AddRecipe();
            HammerConvertRecipe = new HammerRecipe(this);
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 6);
            HammerConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            HammerConvertRecipe.SetResult(ItemID.SandBlock, 5);
            HammerConvertRecipe.AddRecipe();
            //Silt
            HammerConvertRecipe = new HammerRecipe(this);
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 3);
            HammerConvertRecipe.AddIngredient(ItemID.DirtBlock, 3);
            HammerConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            HammerConvertRecipe.SetResult(ItemID.SiltBlock, 5);
            HammerConvertRecipe.AddRecipe();
            HammerConvertRecipe = new HammerRecipe(this);
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 3);
            HammerConvertRecipe.AddIngredient(ItemID.DirtBlock, 3);
            HammerConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            HammerConvertRecipe.SetResult(ItemID.SiltBlock, 5);
            HammerConvertRecipe.AddRecipe();

            HammerAndChiselRecipe ConvertRecipe = new HammerAndChiselRecipe(this);
            //Marble
            ConvertRecipe.AddIngredient(ItemID.PearlstoneBlock, 3);
            ConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            ConvertRecipe.SetResult(ItemID.Marble, 2);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.PearlstoneBlock, 3);
            ConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            ConvertRecipe.SetResult(ItemID.Marble, 2);
            ConvertRecipe.AddRecipe();
            //Granite
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.CrimstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.EbonstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.CrimstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.EbonstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
        }
        public override void MidUpdateTimeWorld()
        {
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {

                //Main.NewText("RitualOfTheStone: " + (VampireWorld.RitualOfTheStone[iterations], VampireWorld.RitualOfTheStone[iterations + 1]));
                //if (p.BloodPoints <= 1)
                //{
                //    Error = true;
                //    ErrorMessage = "Not Enough blood points";
                //}
                if ((VampireWorld.RitualOfTheStone[iterations] && VampireWorld.RitualOfTheMiner[iterations]) || (VampireWorld.RitualOfTheStone[iterations] && VampireWorld.RitualOfMidas[iterations]) || (VampireWorld.RitualOfTheMiner[iterations] && VampireWorld.RitualOfMidas[iterations]))
                {
                    VampireWorld.RitualOfTheStone[iterations] = false;
                    VampireWorld.RitualOfTheMiner[iterations] = false;
                    VampireWorld.RitualOfMidas[iterations] = false;
                    ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        p.SendPackage = true;
                    }
                }
                if (VampireWorld.RoEType[iterations] == TileID.AmberGemspark && VampireWorld.RitualOfTheStone[iterations] == true)
                {
                    Error = true;
                    ErrorMessage = "Please choose a material";
                }
                if (VampireWorld.RitualOfTheStone[iterations] == true && Error != true)
                {
                    //Main.NewText("Working!");
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        StoneRitual((int)VampireWorld.AltarBeingUsed[iterations], (int)VampireWorld.AltarBeingUsed[iterations + 1], Main.player[VampireWorld.AltarOwner[iterations]], VampireWorld.RoEType[iterations]);
                    }
                    else
                    {
                        this.Logger.Warn("Stone Ritual Sent to server");
                        ModPacket StoneRitualOn = this.GetPacket();
                        StoneRitualOn.Write(StoneRitualRecieve);
                        StoneRitualOn.Write(iterations);
                        StoneRitualOn.Write(VampireWorld.AltarOwner[iterations]);
                        StoneRitualOn.Write(VampireWorld.AltarBeingUsed[iterations] + 1);
                        StoneRitualOn.Write(VampireWorld.AltarBeingUsed[iterations + 1] - 2);
                        StoneRitualOn.Write(VampireWorld.RoEType[iterations]);
                        StoneRitualOn.Send();
                    }
                }
                if (VampireWorld.RoMType[iterations] == TileID.AmberGemspark && VampireWorld.RitualOfTheMiner[iterations] == true)
                {
                    Error = true;
                    ErrorMessage = "Please choose a material";
                }
                if (VampireWorld.RitualOfTheMiner[iterations] == true && Error != true)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        MinerRitual((int)VampireWorld.AltarBeingUsed[iterations], (int)VampireWorld.AltarBeingUsed[iterations + 1], Main.player[VampireWorld.AltarOwner[iterations]], VampireWorld.RoMType[iterations]);
                    }
                    else
                    {
                        ModPacket MinerRitualOn = this.GetPacket();
                        MinerRitualOn.Write(MinerRitualRecieve);
                        MinerRitualOn.Write(iterations);
                        MinerRitualOn.Write(VampireWorld.AltarOwner[iterations]);
                        MinerRitualOn.Write(VampireWorld.AltarBeingUsed[iterations] + 1);
                        MinerRitualOn.Write(VampireWorld.AltarBeingUsed[iterations + 1] - 2);
                        MinerRitualOn.Write(VampireWorld.RoMType[iterations]);
                        MinerRitualOn.Send();
                    }
                }
                if (VampireWorld.RitualOfMidas[iterations] == true && Error != true)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        MidasRitual((int)VampireWorld.AltarBeingUsed[iterations], (int)VampireWorld.AltarBeingUsed[iterations + 1], Main.player[VampireWorld.AltarOwner[iterations]], VampireWorld.RoMiType[iterations]);
                    }
                    else
                    {
                        ModPacket MidasRitualOn = this.GetPacket();
                        MidasRitualOn.Write(MidasRitualRecieve);
                        MidasRitualOn.Write(iterations);
                        MidasRitualOn.Write(VampireWorld.AltarOwner[iterations]);
                        MidasRitualOn.Write(VampireWorld.AltarBeingUsed[iterations] + 1);
                        MidasRitualOn.Write(VampireWorld.AltarBeingUsed[iterations + 1] - 2);
                        MidasRitualOn.Write(VampireWorld.RoMiType[iterations]);
                        MidasRitualOn.Send();
                    }
                }

            }
            if (Error)
            {
                Main.NewText("Error!");
            }
            if (UI.BloodAltarUI.visible)
                ErrorTimer++;
            if (Error == true && ErrorTimer > 120)
            {
                Main.NewText("" + ErrorMessage);
                Error = false;
                ErrorTimer = 0;
            }
        }
        public override void Load()
        {
            instance = this;
            HoodUpDownHotkey = RegisterHotKey("Pull hood up or down", "P");
            SupportHotKey = RegisterHotKey("Key to add/remove support debuff", "L");
            VampDashHotKey = RegisterHotKey("Double tap to transform into a bat for a few seconds(Requires vampiric armor)", "D");
            SupportArmorHotKey = RegisterHotKey("Key to use the support armor's buff", "C");
            if (!Main.dedServ)
            {
                //AddEquipTexture(null, EquipType.Legs, "ExampleRobe_Legs", "ExampleMod/Items/Armor/ExampleRobe_Legs");
                AddEquipTexture(new Items.Armor.PyroHead(), null, EquipType.Head, "PyroHead", "VampKnives/Items/Armor/PyromancersHood_Head");
                AddEquipTexture(new Items.Armor.DPyroHead(), null, EquipType.Head, "DPyroHead", "VampKnives/Items/Armor/DarkPyromancersHood_Head");
                AddEquipTexture(new Items.Armor.TransmuterHead(), null, EquipType.Head, "TransmuterHead", "VampKnives/Items/Armor/TransmutersHood_Head");
                AddEquipTexture(new Items.Armor.InvokerHead(), null, EquipType.Head, "InvokerHead", "VampKnives/Items/Armor/InvokersHood_Head");
                AddEquipTexture(new Items.Armor.TechnomancerHead(), null, EquipType.Head, "TechnomancerHead", "VampKnives/Items/Armor/TechnomancersHood_Head");
                AddEquipTexture(new Items.Armor.PartyHead(), null, EquipType.Head, "PartyHead", "VampKnives/Items/Armor/PartyHood_Head");
                AddEquipTexture(new Items.Armor.ShamanHead(), null, EquipType.Head, "ShamanHead", "VampKnives/Items/Armor/ShamansHood_Head");
                AddEquipTexture(new Items.Armor.WitchDoctorHead(), null, EquipType.Head, "WitchDoctorHead", "VampKnives/Items/Armor/WitchDoctorHood_Head");
                AddEquipTexture(new Items.Armor.MageHead(), null, EquipType.Head, "MageHead", "VampKnives/Items/Armor/MagesHood_Head");
                AddEquipTexture(null, EquipType.Head, "BatTransform", "VampKnives/Items/Armor/BatTransform");
                AddEquipTexture(null, EquipType.Head, "BatTransformHidden", "VampKnives/Items/Armor/BatTransformHidden");
                AddEquipTexture(null, EquipType.Wings, "BatFlyMovement", "VampKnives/Items/Armor/BatFlyMovement");
                AddEquipTexture(null, EquipType.Wings, "BatWingsHidden", "VampKnives/Items/Armor/BatWingsHidden");

                customRecources = new UserInterface();
                customResources2 = new UserInterface();
                FirstLoadUI = new UserInterface();
                FirstLoadUIPanel = new EntranceDamageSettingsPanel();
                vampBar = new VampBar();
                VampBar.visible = true;
                RecipePage = new RecipePageState();
                customResources2.SetState(RecipePage);
                customRecources.SetState(vampBar);
                FirstLoadUI.SetState(FirstLoadUIPanel);
                VampireUserInterface = new UserInterface();
                VampireUserInterface2 = new UserInterface();

                WorkbenchSlots = new UserInterface();
                WorkbenchSlotPanel = new WorkbenchSlotState();
                WorkbenchSlots.SetState(WorkbenchSlotPanel);

                UpgradePanelUI = new UserInterface();
                UpgradePanelState = new UpgradePanel();
                UpgradePanelUI.SetState(UpgradePanelState);

                BloodAltarUIPanel = new UserInterface();
                BloodAltarUIState = new BloodAltarUI();
                BloodAltarUIPanel.SetState(BloodAltarUIState);
            }
            base.Load();
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (!Legacy && !Normal && !Unforgiving)
            {
                EntranceDamageSettingsPanel.visible = true;
            }
            else if ((Legacy || Normal || Unforgiving) && !ChangeItemIsHeld && ChosenDifficulty)
            {
                EntranceDamageSettingsPanel.visible = false;
            }
            VampireUserInterface?.Update(gameTime);
            VampireUserInterface2?.Update(gameTime);
            if (IsKnifeRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = true;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsAmmoRecipe)
            {
                RecipePageState.IsAmmoRecipe = true;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsSharpeningRodRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = true;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsPlateRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = true;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsAmmoSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = true;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsKnifeSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = true;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsSharpeningSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = true;
            }
            else
            {
                IsKnifeRecipe = false;
                IsAmmoRecipe = false;
                IsSharpeningRodRecipe = false;
                IsPlateRecipe = false;
                IsAmmoSculptRecipe = false;
                IsKnifeSculptRecipe = false;
                IsSharpeningSculptRecipe = false;
            }
        }
        bool PacketWorking;
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Contains("Vanilla: Mouse Text"));
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("VampBars: Blood Resource Bar", delegate
                {
                    if (VampBar.visible)
                    {
                        customRecources.Update(Main._drawInterfaceGameTime);
                        vampBar.Draw(Main.spriteBatch);
                    }
                    if (RecipePageState.visible)
                    {
                        customResources2.Update(Main._drawInterfaceGameTime);
                        RecipePage.Draw(Main.spriteBatch);
                    }
                    if (EntranceDamageSettingsPanel.visible)
                    {
                        FirstLoadUI.Update(Main._drawInterfaceGameTime);
                        FirstLoadUIPanel.Draw(Main.spriteBatch);
                    }
                    if (WorkbenchSlotState.visible)
                    {
                        WorkbenchSlots.Update(Main._drawInterfaceGameTime);
                        WorkbenchSlotPanel.Draw(Main.spriteBatch);
                    }
                    if (UpgradePanel.visible)
                    {
                        UpgradePanelUI.Update(Main._drawInterfaceGameTime);
                        UpgradePanelState.Draw(Main.spriteBatch);
                    }
                    if (BloodAltarUI.visible)
                    {
                        BloodAltarUIPanel.Update(Main._drawInterfaceGameTime);
                        BloodAltarUIState.Draw(Main.spriteBatch);
                    }
                    return true;
                }));
                if (Main.playerInventory == false && WorkbenchSlotState.visible)
                {
                    WorkbenchSlotState.visible = false;
                }
                if (Main.playerInventory == false && UpgradePanel.visible)
                {
                    UpgradePanel.visible = false;
                }
                if (Main.playerInventory == false && BloodAltarUI.visible)
                {
                    BloodAltarUI.visible = false;
                }
            }
            inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "Skin shop UI",
                    delegate
                    {
                        VampireUserInterface.Draw(Main.spriteBatch, new GameTime());
                        VampireUserInterface2.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        public override void Unload()
        {
            HoodUpDownHotkey = null;
            SupportHotKey = null;
            VampDashHotKey = null;
            SupportArmorHotKey = null;
            instance = null;
            base.Unload();
        }
        int Packet2 = 22;
        int Packet5 = 55;
        int Packet6 = 66;
        int BatTransformRecieve = 88;
        int BatTransformSend = 89;
        int SupportArmorRecieve = 99;
        int SupportArmorSend = 100;
        int Packet4 = 44;
        public static int AltarPressedRecieveLists = 23;
        int AltarPressedSendLists = 24;
        public static int RitualsRecieve = 26;
        int RitualsSend = 27;
        public static int KillBlocksRecieve = 34;
        int KillsBlocksSend = 35;
        int StoneRitualRecieve = 36;
        int StoneRitualSend = 37;
        int MinerRitualRecieve = 38;
        int MinerRitualSend = 39;
        int MidasRitualRecieve = 40;
        int MidasRitualSend = 41;

        int DustType;
        int DustTimer;

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            int idVariable = reader.ReadInt32();
            if (idVariable == 11)
            {
                bool KeyPressed = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                ModPacket packet2 = this.GetPacket();
                packet2.Write(Packet2);
                packet2.Write(KeyPressed);
                packet2.Write(playerID);
                packet2.Send(-1, playerID);
            }
            if (idVariable == Packet2)
            {
                bool KeyPressed2 = reader.ReadBoolean();

                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<ExamplePlayer>().HoodIsVisible = KeyPressed2;
            }
            if (idVariable == 33)
            {
                Main.LocalPlayer.GetModPlayer<ExamplePlayer>().NeckProgress++;
            }

            if (idVariable == Packet5)
            {
                int Owner = reader.ReadInt32();
                int Decision = reader.ReadInt32();
                int SyncLifeAmount = reader.ReadInt32();
                bool BuffState = Main.player[Owner].HasBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>());
                ModPacket packet5 = this.GetPacket();
                packet5.Write(Packet6);
                packet5.Write(Decision);
                packet5.Write(SyncLifeAmount);
                packet5.Write(Owner);
                packet5.Write(BuffState);
                packet5.Send(-1, Owner);
            }
            if (idVariable == Packet6)
            {
                int Decision = reader.ReadInt32();
                int SyncLifeAmount = reader.ReadInt32();
                int Owner = reader.ReadInt32();
                bool BuffState = reader.ReadBoolean();
                if (BuffState)
                    Main.player[Owner].AddBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>(), 60);
                Main.player[Decision].statLife += (SyncLifeAmount);
                if (SyncLifeAmount >= 1)
                    Main.player[Decision].HealEffect(SyncLifeAmount, false);
            }
            if (idVariable == BatTransformRecieve)
            {
                bool Transform = reader.ReadBoolean();
                bool HasTablet = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(BatTransformSend);
                packet.Write(Transform);
                packet.Write(HasTablet);
                packet.Write(playerID);
                packet.Send(-1, playerID);
            }
            if (idVariable == BatTransformSend)
            {
                bool Transform = reader.ReadBoolean();
                bool HasTablet = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<ExamplePlayer>().Transform = Transform;
                Main.player[playerID].GetModPlayer<ExamplePlayer>().HasTabletEquipped = HasTablet;
            }
            if (idVariable == SupportArmorRecieve)
            {
                int PlayerToBuff = reader.ReadInt32();
                int BuffCountStore = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(SupportArmorSend);
                packet.Write(PlayerToBuff);
                packet.Write(BuffCountStore);
                packet.Send(-1, PlayerID);
            }
            if (idVariable == SupportArmorSend)
            {
                int PlayerToBuff = reader.ReadInt32();
                int BuffCountStore = reader.ReadInt32();
                Main.player[PlayerToBuff].AddBuff(ModContent.BuffType<Buffs.SupportBuff>(), 600);
                Main.player[PlayerToBuff].GetModPlayer<ExamplePlayer>().BuffCountStore = BuffCountStore;
            }
            if (idVariable == AltarPressedRecieveLists)
            {
                PacketWorking = true;
                int Count = reader.ReadInt32();
                List<int> AltarBeingUsedList = new List<int>();
                List<bool> RitualOfTheStone = new List<bool>();
                List<ushort> RoEType = new List<ushort>();
                List<bool> RitualOfTheMiner = new List<bool>();
                List<ushort> RoMType = new List<ushort>();
                List<bool> RitualOfMidas = new List<bool>();
                List<short> RoMiType = new List<short>();
                List<int> AltarOwner = new List<int>();
                for (int i = 0; i < Count; i++)
                {
                    AltarBeingUsedList.Add(reader.ReadInt32());
                    RitualOfTheStone.Add(reader.ReadBoolean());
                    RoEType.Add(reader.ReadUInt16());
                    RitualOfTheMiner.Add(reader.ReadBoolean());
                    RoMType.Add(reader.ReadUInt16());
                    RitualOfMidas.Add(reader.ReadBoolean());
                    RoMiType.Add(reader.ReadInt16());
                    AltarOwner.Add(reader.ReadInt32());
                }
                int PlayerID = reader.ReadInt32();
                //for (int gj = 0; gj < AltarBeingUsedList.Count; gj += 2)
                //{
                //    this.Logger.Warn("Server altar list: (" + AltarBeingUsedList[gj] + "," + AltarBeingUsedList[gj + 1] + ")");
                //}
                ModPacket packet = this.GetPacket();
                packet.Write(AltarPressedSendLists);
                packet.Write(Count);
                for (int g = 0; g < Count; g++)
                {
                    packet.Write(AltarBeingUsedList[g]);
                    packet.Write(RitualOfTheStone[g]);
                    packet.Write(RoEType[g]);
                    packet.Write(RitualOfTheMiner[g]);
                    packet.Write(RoMType[g]);
                    packet.Write(RitualOfMidas[g]);
                    packet.Write(RoMiType[g]);
                    packet.Write(AltarOwner[g]);
                }
                packet.Write(PlayerID);
                packet.Send(-1, PlayerID);
            }
            if (idVariable == AltarPressedSendLists)
            {
                int Count = reader.ReadInt32();
                List<int> AltarBeingUsedList = new List<int>();
                List<bool> RitualOfTheStone = new List<bool>();
                List<ushort> RoEType = new List<ushort>();
                List<bool> RitualOfTheMiner = new List<bool>();
                List<ushort> RoMType = new List<ushort>();
                List<bool> RitualOfMidas = new List<bool>();
                List<short> RoMiType = new List<short>();
                List<int> AltarOwner = new List<int>();
                for (int i = 0; i < Count; i++)
                {
                    AltarBeingUsedList.Add(reader.ReadInt32());
                    RitualOfTheStone.Add(reader.ReadBoolean());
                    RoEType.Add(reader.ReadUInt16());
                    RitualOfTheMiner.Add(reader.ReadBoolean());
                    RoMType.Add(reader.ReadUInt16());
                    RitualOfMidas.Add(reader.ReadBoolean());
                    RoMiType.Add(reader.ReadInt16());
                    AltarOwner.Add(reader.ReadInt32());
                }
                int PlayerID = reader.ReadInt32();
                //for (int gj = 0; gj < AltarBeingUsedList.Count; gj += 2)
                //{
                //    this.Logger.Info("Sent altar list: (" + AltarBeingUsedList[gj] + "," + AltarBeingUsedList[gj + 1] + ")");
                //}
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    VampireWorld.AltarBeingUsed = AltarBeingUsedList;
                    VampireWorld.RitualOfTheStone = RitualOfTheStone;
                    VampireWorld.RoEType = RoEType;
                    VampireWorld.RitualOfTheMiner = RitualOfTheMiner;
                    VampireWorld.RoMType = RoMType;
                    VampireWorld.RitualOfMidas = RitualOfMidas;
                    VampireWorld.RoMiType = RoMiType;
                    VampireWorld.AltarOwner = AltarOwner;
                }
            }
            if (idVariable == RitualsRecieve)
            {
                int Count = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                List<bool> RitualOfTheStone = new List<bool>();
                List<ushort> RoEType = new List<ushort>();
                List<bool> RitualOfTheMiner = new List<bool>();
                List<ushort> RoMType = new List<ushort>();
                List<bool> RitualOfMidas = new List<bool>();
                List<short> RoMiType = new List<short>();
                List<int> AltarOwner = new List<int>();
                for (int i = 0; i < Count; i++)
                {
                    //AltarBeingUsedList.Add(reader.ReadInt32());
                    RitualOfTheStone.Add(reader.ReadBoolean());
                    RoEType.Add(reader.ReadUInt16());
                    RitualOfTheMiner.Add(reader.ReadBoolean());
                    RoMType.Add(reader.ReadUInt16());
                    RitualOfMidas.Add(reader.ReadBoolean());
                    RoMiType.Add(reader.ReadInt16());
                    AltarOwner.Add(reader.ReadInt32());
                }
                //for (int gj = 0; gj < Count; gj += 2)
                //{
                //    //this.Logger.Info("AltarsR: " + new Vector2(AltarBeingUsedList[gj], AltarBeingUsedList[gj + 1]));
                //    //this.Logger.Info("RitStoneR: " + (RitualOfTheStone[gj], RitualOfTheStone[gj + 1]));
                //    //this.Logger.Info("StoneTypeR: " + new Vector2(RoEType[gj], RoEType[gj + 1]));
                //    //this.Logger.Info("RitMinerR: " + (RitualOfTheMiner[gj], RitualOfTheMiner[gj + 1]));
                //    //this.Logger.Info("MinerTypeR: " + new Vector2(RoMType[gj], RoMType[gj + 1]));
                //    //this.Logger.Info("RitMidasR: " + (RitualOfMidas[gj], RitualOfMidas[gj + 1]));
                //    //this.Logger.Info("MidasTypeR: " + new Vector2(RoMiType[gj], RoMiType[gj + 1]));
                //}
                ModPacket packet = this.GetPacket();
                packet.Write(RitualsSend);
                packet.Write(Count);
                for (int g = 0; g < Count; g++)
                {
                    packet.Write(RitualOfTheStone[g]);
                    packet.Write(RoEType[g]);
                    packet.Write(RitualOfTheMiner[g]);
                    packet.Write(RoMType[g]);
                    packet.Write(RitualOfMidas[g]);
                    packet.Write(RoMiType[g]);
                    packet.Write(AltarOwner[g]);
                }
                packet.Send(-1, PlayerID);
            }

            if (idVariable == RitualsSend)
            {
                //this.Logger.Info("Player Recieved Changes");
                int Count = reader.ReadInt32();
                //List<int> AltarBeingUsedList = new List<int>();
                List<bool> RitualOfTheStone = new List<bool>();
                List<ushort> RoEType = new List<ushort>();
                List<bool> RitualOfTheMiner = new List<bool>();
                List<ushort> RoMType = new List<ushort>();
                List<bool> RitualOfMidas = new List<bool>();
                List<short> RoMiType = new List<short>();
                List<int> AltarOwner = new List<int>();
                for (int i = 0; i < Count; i++)
                {
                    RitualOfTheStone.Add(reader.ReadBoolean());
                    RoEType.Add(reader.ReadUInt16());
                    RitualOfTheMiner.Add(reader.ReadBoolean());
                    RoMType.Add(reader.ReadUInt16());
                    RitualOfMidas.Add(reader.ReadBoolean());
                    RoMiType.Add(reader.ReadInt16());
                    AltarOwner.Add(reader.ReadInt32());
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    //VampireWorld.AltarBeingUsed = AltarBeingUsedList;
                    VampireWorld.AltarOwner = AltarOwner;
                    VampireWorld.RitualOfTheStone = RitualOfTheStone;
                    VampireWorld.RoEType = RoEType;
                    VampireWorld.RitualOfTheMiner = RitualOfTheMiner;
                    VampireWorld.RoMType = RoMType;
                    VampireWorld.RitualOfMidas = RitualOfMidas;
                    VampireWorld.RoMiType = RoMiType;
                }
            }
            if (idVariable == KillBlocksRecieve)
            {
                //this.Logger.Info("Server Recieved Changes for Kill");
                int identifier = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                int Count = reader.ReadInt32();
                List<bool> RitualOfTheStone = new List<bool>();
                List<bool> RitualOfTheMiner = new List<bool>();
                List<bool> RitualOfMidas = new List<bool>();
                for (int i = 0; i < Count; i++)
                {
                    RitualOfTheStone.Add(reader.ReadBoolean());
                    RitualOfTheMiner.Add(reader.ReadBoolean());
                    RitualOfMidas.Add(reader.ReadBoolean());
                }
                WorldGen.KillTile(PosX, PosY);
                WorldGen.KillTile(PosX, PosY + 1, false, false, true);

                ModPacket packet = this.GetPacket();
                packet.Write(KillsBlocksSend);
                packet.Write(identifier);
                packet.Write(PosX);
                packet.Write(PosY);
                packet.Write(Count);
                for (int g = 0; g < Count; g++)
                {
                    packet.Write(RitualOfTheStone[g]);
                    packet.Write(RitualOfTheMiner[g]);
                    packet.Write(RitualOfMidas[g]);
                }
                packet.Send(-1, -1);
            }
            if (idVariable == KillsBlocksSend)
            {
                int identifier = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                int Count = reader.ReadInt32();
                List<bool> RitualOfTheStone = new List<bool>();
                List<bool> RitualOfTheMiner = new List<bool>();
                List<bool> RitualOfMidas = new List<bool>();
                for (int i = 0; i < Count; i++)
                {
                    RitualOfTheStone.Add(reader.ReadBoolean());
                    RitualOfTheMiner.Add(reader.ReadBoolean());
                    RitualOfMidas.Add(reader.ReadBoolean());
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    VampireWorld.RitualOfTheStone = RitualOfTheStone;
                    VampireWorld.RitualOfTheMiner = RitualOfTheMiner;
                    VampireWorld.RitualOfMidas = RitualOfMidas;
                }
                WorldGen.KillTile(PosX, PosY);
                WorldGen.KillTile(PosX, PosY + 1, false, false, true);
            }
            if (idVariable == StoneRitualRecieve)
            {
                //this.Logger.Warn("Stone Ritual Recieved");
                int identifier = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                ushort tileid = reader.ReadUInt16();

                if (tileid == TileID.Sand || tileid == TileID.Silt || tileid == TileID.SnowBlock)
                {
                    WorldGen.PlaceTile(PosX, PosY + 1, ModContent.TileType<Tiles.AltarPillar>());
                }
                WorldGen.PlaceTile(PosX, PosY, tileid);

                ModPacket packet = this.GetPacket();
                packet.Write(StoneRitualSend);
                packet.Write(identifier);
                packet.Write(PlayerID);
                packet.Write(PosX);
                packet.Write(PosY);
                packet.Write(tileid);
                packet.Send(-1, -1);
                //this.Logger.Warn("Stone Ritual Sent to players");
            }
            if (idVariable == StoneRitualSend)
            {
                //this.Logger.Warn("Stone Ritual Recieved By Players");
                int identifier = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                ushort tileid = reader.ReadUInt16();
                StoneRitual(PosX - 1, PosY + 2, Main.player[PlayerID], tileid);
                if (tileid == TileID.Stone)
                {
                    DustType = 1;
                }
                else if (tileid == TileID.Dirt)
                {
                    DustType = 0;
                }
                else if (tileid == TileID.Sand)
                {
                    DustType = 32;
                }
                else if (tileid == TileID.Silt)
                {
                    DustType = 121;
                }
                else if (tileid == TileID.SnowBlock)
                {
                    DustType = 51;
                }
                DustTimer++;
                if (DustTimer >= 2)
                {
                    ExamplePlayer.OvalDust(new Vector2(16 * PosX + 4.5f, 16 * (PosY + 1) + 4), 2, 0.8f, Color.White, DustType, 1f);
                    DustTimer = 0;
                }
            }
            if (idVariable == MinerRitualRecieve)
            {
                int identifier = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                ushort tileid = reader.ReadUInt16();

                WorldGen.PlaceTile(PosX, PosY, tileid);

                ModPacket packet = this.GetPacket();
                packet.Write(MinerRitualSend);
                packet.Write(identifier);
                packet.Write(PlayerID);
                packet.Write(PosX);
                packet.Write(PosY);
                packet.Write(tileid);
                packet.Send(-1, -1);
            }
            if (idVariable == MinerRitualSend)
            {
                int identifier = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                ushort tileid = reader.ReadUInt16();
                MinerRitual(PosX - 1, PosY + 2, Main.player[PlayerID], tileid);
                if (tileid == TileID.Copper)
                {
                    DustType = 9;
                }
                else if (tileid == TileID.Tin)
                {
                    DustType = 81;
                }
                else if (tileid == TileID.Iron)
                {
                    DustType = 8;
                }
                else if (tileid == TileID.Lead)
                {
                    DustType = 82;
                }
                else if (tileid == TileID.Silver)
                {
                    DustType = 11;
                }
                else if (tileid == TileID.Tungsten)
                {
                    DustType = 83;
                }
                else if (tileid == TileID.Gold)
                {
                    DustType = 10;
                }
                else if (tileid == TileID.Platinum)
                {
                    DustType = 84;
                }
                else if (tileid == TileID.Meteorite)
                {
                    DustType = 127;
                }
                else if (tileid == TileID.Demonite)
                {
                    DustType = 65;
                }
                else if (tileid == TileID.Crimtane)
                {
                    DustType = 117;
                }
                else if (tileid == TileID.Hellstone)
                {
                    DustType = 6;
                }
                else if (tileid == TileID.Cobalt)
                {
                    DustType = 48;
                }
                else if (tileid == TileID.Palladium)
                {
                    DustType = 144;
                }
                else if (tileid == TileID.Mythril)
                {
                    DustType = 49;
                }
                else if (tileid == TileID.Orichalcum)
                {
                    DustType = 145;
                }
                else if (tileid == TileID.Adamantite)
                {
                    DustType = 50;
                }
                else if (tileid == TileID.Titanium)
                {
                    DustType = 146;
                }
                else if (tileid == TileID.Chlorophyte)
                {
                    DustType = 128;
                }
                else if (tileid == TileID.LunarOre)
                {
                    DustType = 242;
                }
                DustTimer++;
                if (DustTimer >= 2)
                {
                    ExamplePlayer.OvalDust(new Vector2(16 * PosX + 4.5f, 16 * (PosY + 1) + 4), 2, 0.8f, Color.White, DustType, 1f);
                    DustTimer = 0;
                }
            }
            if (idVariable == MidasRitualRecieve)
            {
                int identifier = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                short tileid = reader.ReadInt16();

                Item.NewItem(new Vector2(PosX * 16, PosY * 16), tileid);

                ModPacket packet = this.GetPacket();
                packet.Write(MidasRitualSend);
                packet.Write(identifier);
                packet.Write(PlayerID);
                packet.Write(PosX);
                packet.Write(PosY);
                packet.Write(tileid);
                packet.Send(-1, -1);
            }
            if (idVariable == MidasRitualSend)
            {
                int identifier = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                int PosX = reader.ReadInt32();
                int PosY = reader.ReadInt32();
                short itemid = reader.ReadInt16();
                MidasRitual(PosX, PosY, Main.player[PlayerID], itemid);
                DustTimer++;
                if (DustTimer >= 5)
                {
                    if (itemid == ItemID.CopperCoin)
                    {
                        DustType = 9;
                    }
                    else if (itemid == ItemID.SilverCoin)
                    {
                        DustType = 11;
                    }
                    else if (itemid == ItemID.GoldCoin)
                    {
                        DustType = 10;
                    }
                    else if (itemid == ItemID.PlatinumCoin)
                    {
                        DustType = 84;
                    }
                    ExamplePlayer.OvalDust(new Vector2(16 * PosX + 4.5f, 16 * (PosY + 1) + 4), 1, 2f, Color.White, DustType, 1f);
                    DustTimer = 0;
                }
            }
            base.HandlePacket(reader, whoAmI);
        }
        public void StoneRitual(int i, int j, Player player, ushort tileid)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            //Main.NewText("RitualRun");
            //Main.NewText("Passed Coors: " + new Vector2(i, j));
            if (p.BloodPoints > 1 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (tileid == TileID.Stone)
                {
                    DustType = 1;
                }
                else if (tileid == TileID.Dirt)
                {
                    DustType = 0;
                }
                else if (tileid == TileID.Sand)
                {
                    DustType = 32;
                }
                else if (tileid == TileID.Silt)
                {
                    DustType = 121;
                }
                else if (tileid == TileID.SnowBlock)
                {
                    DustType = 51;
                }
                DustTimer++;
                if (DustTimer >= 2)
                {
                    ExamplePlayer.OvalDust(new Vector2(16 * (i + 1) + 4.5f, 16 * (j - 1) + 4), 2, 0.8f, Color.White, DustType, 1f);
                    DustTimer = 0;
                }
            }
            if (Main.tile[i + 1, j - 2].type != tileid)
            {
                p.BloodPoints -= 1;
            }
            if (tileid == TileID.Sand || tileid == TileID.Silt || tileid == TileID.SnowBlock)
            {
                WorldGen.PlaceTile(i + 1, j - 1, ModContent.TileType<Tiles.AltarPillar>());
            }
            WorldGen.PlaceTile(i + 1, j - 2, tileid);
        }

        int PointCost;
        public void MinerRitual(int i, int j, Player player, ushort tileid)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            //Main.NewText("RitualRun");
            //Main.NewText("Passed Coors: " + new Vector2(i, j));
            if (p.BloodPoints > 1)
            {
                if (tileid == TileID.Copper || tileid == TileID.Tin)
                {
                    PointCost = 1;
                }
                else if (tileid == TileID.Iron || tileid == TileID.Lead)
                {
                    PointCost = 2;
                }
                else if (tileid == TileID.Silver || tileid == TileID.Tungsten)
                {
                    PointCost = 4;
                }
                else if (tileid == TileID.Gold || tileid == TileID.Platinum)
                {
                    PointCost = 8;
                }
                else if (tileid == TileID.Meteorite)
                {
                    PointCost = 12;
                }
                else if (tileid == TileID.Demonite || tileid == TileID.Crimtane)
                {
                    PointCost = 16;
                }
                else if (tileid == TileID.Hellstone)
                {
                    PointCost = 24;
                }
                else if (tileid == TileID.Cobalt || tileid == TileID.Palladium)
                {
                    PointCost = 50;
                }
                else if (tileid == TileID.Mythril || tileid == TileID.Orichalcum)
                {
                    PointCost = 75;
                }
                else if (tileid == TileID.Adamantite || tileid == TileID.Titanium)
                {
                    PointCost = 100;
                }
                else if (tileid == TileID.Chlorophyte)
                {
                    PointCost = 150;
                }
                else if (tileid == TileID.LunarOre)
                {
                    PointCost = 300;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (tileid == TileID.Copper)
                    {
                        DustType = 9;
                    }
                    else if (tileid == TileID.Tin)
                    {
                        DustType = 81;
                    }
                    else if (tileid == TileID.Iron)
                    {
                        DustType = 8;
                    }
                    else if (tileid == TileID.Lead)
                    {
                        DustType = 82;
                    }
                    else if (tileid == TileID.Silver)
                    {
                        DustType = 11;
                    }
                    else if (tileid == TileID.Tungsten)
                    {
                        DustType = 83;
                    }
                    else if (tileid == TileID.Gold)
                    {
                        DustType = 10;
                    }
                    else if (tileid == TileID.Platinum)
                    {
                        DustType = 84;
                    }
                    else if (tileid == TileID.Meteorite)
                    {
                        DustType = 127;
                    }
                    else if (tileid == TileID.Demonite)
                    {
                        DustType = 65;
                    }
                    else if (tileid == TileID.Crimtane)
                    {
                        DustType = 117;
                    }
                    else if (tileid == TileID.Hellstone)
                    {
                        DustType = 6;
                    }
                    else if (tileid == TileID.Cobalt)
                    {
                        DustType = 48;
                    }
                    else if (tileid == TileID.Palladium)
                    {
                        DustType = 144;
                    }
                    else if (tileid == TileID.Mythril)
                    {
                        DustType = 49;
                    }
                    else if (tileid == TileID.Orichalcum)
                    {
                        DustType = 145;
                    }
                    else if (tileid == TileID.Adamantite)
                    {
                        DustType = 50;
                    }
                    else if (tileid == TileID.Titanium)
                    {
                        DustType = 146;
                    }
                    else if (tileid == TileID.Chlorophyte)
                    {
                        DustType = 128;
                    }
                    else if (tileid == TileID.LunarOre)
                    {
                        DustType = 242;
                    }
                    DustTimer++;
                    if (DustTimer >= 2)
                    {
                        ExamplePlayer.OvalDust(new Vector2(16 * (i + 1) + 4.5f, 16 * (j - 1) + 4), 2, 0.8f, Color.White, DustType, 1f);
                        DustTimer = 0;
                    }
                }
                if (Main.tile[i + 1, j - 2].type != tileid)
                {
                    p.BloodPoints -= PointCost;
                }
                WorldGen.PlaceTile(i + 1, j - 2, tileid);
            }
        }
        public void MidasRitual(int i, int j, Player player, short itemid)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            int PointCost = 1;
            if (p.BloodPoints > 1)
            {
                DustTimer++;
                if (DustTimer >= 5)
                {
                    if (itemid == ItemID.CopperCoin)
                    {
                        DustType = 9;
                        PointCost = 1;
                    }
                    else if (itemid == ItemID.SilverCoin)
                    {
                        DustType = 11;
                        PointCost = 10;
                    }
                    else if (itemid == ItemID.GoldCoin)
                    {
                        DustType = 10;
                        PointCost = 100;
                    }
                    else if (itemid == ItemID.PlatinumCoin)
                    {
                        DustType = 11;
                        PointCost = 999;
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        ExamplePlayer.OvalDust(new Vector2(16 * (i + 1) + 4.5f, 16 * (j - 1) + 4), 1, 2f, Color.White, DustType, 1f);
                    }
                    DustTimer = 0;
                }
                p.BloodPoints -= PointCost;
                Item.NewItem(new Vector2(16 * (i + 1) + 4.5f, 16 * (j - 1) + 4), 1, 1, itemid);
            }
        }
    }
}