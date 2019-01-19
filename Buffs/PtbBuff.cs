using Terraria;
using Terraria.ModLoader;

namespace PetTerraBeam.Buffs
{
	public class PetTerraBeam : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Terra Beam");
			Description.SetDefault("A Pet Terra Beam is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<PtbPlayer>(mod).petTerraBeam = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("PetTerraBeam")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("PetTerraBeam"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}