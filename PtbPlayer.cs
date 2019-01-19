using Terraria.ModLoader;

namespace PetTerraBeam
{
    public class PtbPlayer : ModPlayer
    {
        public bool petTerraBeam = false;

        public override void ResetEffects()
        {
            petTerraBeam = false;
        }
    }
}