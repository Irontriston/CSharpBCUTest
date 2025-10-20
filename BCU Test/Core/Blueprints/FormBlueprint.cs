using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    //This will take the role of the foundational blueprint for enemies and units.
    internal class FormBlueprint : OtherBlueprint
    {
        public int FormId;
        public Vector2 SetLevel; //Handles both regular and + levels.
        public string Name, Description;
        public int MinimumPosition;
        public int MaxHealth;
        public int HitBacks;
        public int Price;
        public int RespawnTime;
        public int SpawnLimit;
        public Vector2 Layer;
        public int SpawnCapWeight;
        public int MovementSpeed;
        public int TargetWidth; //Bc the actual hitbox is more of a hit'point', this only affects targeting.
        public int TimeBetweenAttacks;
        public int StandingRange;
        public int AttackBaseRange;
        public List<AttackBlueprint> Attacks;
        public bool BlocksWaves, CommonProc;
        public List<Ability> AbilitySet;
        public List<Traits> SelfTraits;
        public List<Traits> TargetTraits;
        public List<SubTraits> SelfSubTraits;
        
        public FormBlueprint()
        {
            Name = "";
            Description = "";
            MaxHealth = 200;
            HitBacks = 4;
            RespawnTime = 120;
            SpawnLimit = -1;
            MovementSpeed = 6;
            SpawnCapWeight = 1;
            Layer = new Vector2(0, 9);
            MinimumPosition = 200;
            TimeBetweenAttacks = 0;
            StandingRange = AttackBaseRange = 0;
            Attacks = [new AttackBlueprint()];
            BlocksWaves = false;
            CommonProc = false;
            AbilitySet = [];
            SelfTraits = [];
            SelfSubTraits = [];
            TargetTraits = [];
        }
    }
}
