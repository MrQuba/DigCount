using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DigCount.Common
{
	public class DigPlayer : ModPlayer
	{
		public int digCount;
		public override void SaveData(TagCompound tag)
		{
			tag["digCount"] = digCount;
		}

		public override void LoadData(TagCompound tag)
		{
			digCount = tag.GetInt("digCount");
		}
	}
}
