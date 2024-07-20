using DigCount.Common;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace DigCount.Content
{
	// Most of UI code comes from here: https://github.com/tModLoader/tModLoader/wiki/Advanced-guide-to-custom-UI
	class UI : UIState { }
	public class UISystem : ModSystem
	{
		internal UserInterface Interface;
		internal UI digCountUI;
		public override void Load()
		{
			if (!Main.dedServ)
			{
				Interface = new UserInterface();

				digCountUI = new UI();
				digCountUI.Activate(); 
			}
		}
		private GameTime _lastUpdateUiGameTime;

		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;
			if (Interface?.CurrentState != null)
			{
				Interface.Update(gameTime);
			}
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"MyMod: Tile Destruction Counter",
					delegate
					{
						string text = "Tiles Destroyed: " + Main.LocalPlayer.GetModPlayer<DigPlayer>().digCount;
						Utils.DrawBorderString(Main.spriteBatch, text, new Vector2(10, 10), Color.White);
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
		public override void Unload()
		{
			digCountUI = null;
		}
	}

}