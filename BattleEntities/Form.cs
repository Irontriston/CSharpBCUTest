using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.BattleEntities
{
    public class Form
    {
        int EntityId;
        string Name;
        string Description;
        int Position;
        int MinimumPosition;
        int Health;
        int MaxHealth;
        int HitBacks;
        byte Layer;
        int CapacityUsage;
        int MovementSpeed;
        int TargetWidth;
        int TimeBetweenAttacks;
        int StandingRange;
        int AttackBaseRange;

        public Form()
        {
            Name = "";
            Description = "";
            Health = MaxHealth = 200;
            HitBacks = 4;
            MovementSpeed = 6;
            CapacityUsage = 1;
            Position = Layer = 0;
            MinimumPosition = 200;
            TimeBetweenAttacks = 0;
            StandingRange = AttackBaseRange = 0;
        }
    }
}
