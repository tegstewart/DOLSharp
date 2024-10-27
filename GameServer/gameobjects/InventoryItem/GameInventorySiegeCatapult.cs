/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */
using System;
using System.Reflection;
using System.Collections.Generic;

using DOL.Language;
using DOL.GS.PacketHandler;
using DOL.Database;
using DOL.GS.Spells;

using log4net;

namespace DOL.GS
{
	/// <summary>
	/// This class represents a Siege Catapult inventory item
	/// </summary>
	public class GameInventorySiegeCatapult : GameInventoryItem, IGameInventoryItem, ITranslatableObject
	{

		public GameInventorySiegeCatapult()
			: base()
		{
		}

		public GameInventorySiegeCatapult(ItemTemplate template)
			: base(template)
		{
		}

		public GameInventorySiegeCatapult(ItemUnique template)
			: base(template)
		{
		}

		public GameInventorySiegeCatapult(InventoryItem item)
			: base(item)
		{
			OwnerID = item.OwnerID;
			ObjectId = item.ObjectId;
		}


		/// <summary>
		/// Try and use this item
		/// </summary>
		/// <param name="player"></param>
		/// <returns>true if item use is handled here</returns>
		public override bool Use(GamePlayer player)
		{
			// Create the siege catapult 
			GameSiegeCatapult cat = new GameSiegeCatapult();

			// Level, name and model of the siege catapult are retrieved from the inventory item
			cat.Level = Convert.ToByte(Level);
			cat.Name = Name;
			cat.Model = (ushort) Model;
			cat.Position = player.Position;
			cat.Realm = player.Realm;
			cat.AddToWorld();

			// Remove current item from player's inventory 
			InventoryItem item = player.Inventory.GetItem((eInventorySlot)SlotPosition);
			player.Inventory.RemoveItem(item);

			return true;
		}
	}

}
