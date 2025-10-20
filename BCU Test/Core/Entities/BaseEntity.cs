using Battle_Cats_Ultimate_Test;
using Battle_Cats_Ultimate_Test.Blueprints;
using System;

namespace BCU_Test.Core
{
	abstract class BaseEntity
	{
		public short EntityId;
		public float Position, LastPosition;
		public sbyte DrawLayer;
		public byte FactionId; //I'd hope no one is having more than 256 factions out at once, but who knows. /shrug
		public float AnimFramePoint;
		public bool FacingRight;//Replacing 'ForwardDirection' as having an entire int for 1 or 0 is kinda absurd.

		public void PreAttackUpdate() { }
		public void OnAttack() { }//Should only be called when a unit is attacking.
		public void PostAttackUpdate() { }
		public void OnSpawnAttack(AttackBlueprint attackBP) { }
	}
}
