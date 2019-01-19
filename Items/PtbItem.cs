using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PetTerraBeam.Items
{
	public class PetTerraBeam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra Blade");
			Tooltip.SetDefault("Summons a Pet Terra Beam");
		}

		public override void SetDefaults()
		{
            item.damage = 0;
            item.useStyle = 1;
			item.shoot = mod.ProjectileType("PetTerraBeam");
            item.width = 30;
            item.height = 30;
            item.UseSound = SoundID.Item2;
            item.useAnimation = 20;
            item.useTime = 20;
            item.rare = 11;
            item.noMelee = true;
            item.value = 1000000;
			item.buffType = mod.BuffType("PetTerraBeam");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 3);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TerraBlade);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 999);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(ItemID.TerraBlade);
            recipe.AddRecipe();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}