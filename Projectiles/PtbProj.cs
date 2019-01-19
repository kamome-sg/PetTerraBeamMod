using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PetTerraBeam.Projectiles
{
	public class PetTerraBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pet Terra Beam");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.BabySkeletronHead);
            projectile.light = 1.0f;
			aiType = ProjectileID.BabySkeletronHead;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			PtbPlayer modPlayer = player.GetModPlayer<PtbPlayer>(mod);
			if (player.dead)
			{
				modPlayer.petTerraBeam = false;
			}
			if (modPlayer.petTerraBeam)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}