using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    
    public enum TalentOrbType
    {
        Attack = 1,
        Defense = 2,
        Strong = 3,
        Resist = 4,
        Massive = 5
    }
    public enum RarityType
    {
        Normal = 0,
        EX = 1,
        Rare = 2,
        SuperRare = 3,
        UberRare = 4,
        LegendRare = 5
    }
    public struct TalentOrb
    {
        TalentOrbType type;
        byte grade;
        public TalentOrb(TalentOrbType type, byte grade)
        {
            this.type = type;
            this.grade = grade;
        }
    }
    public class Unit
    {
        //Handles both regular and + levels.
        public Vector2 Level;
        public Vector2 MaxLevel;
        public byte[] LevelCurve;
        public RarityType Rarity;
        public string Name;
        public List<FormBlueprint> Forms;


    }
}
