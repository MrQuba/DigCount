using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DigCount.Common
{
	public class Tile : GlobalTile
	{
		public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{

			base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);

			Player player = Main.LocalPlayer;
			if (!fail && !effectOnly)
			{
				if(Main.tileSolid[type])
				if (player != null && player.active)
				{
					player.GetModPlayer<DigPlayer>().digCount++;
				}
			}
		}
	}
}
