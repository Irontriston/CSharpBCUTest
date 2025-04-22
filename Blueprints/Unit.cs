using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    public enum TalentOrbTypes
    {
        Attack = 1,
        Defense = 2,
        Strong = 3,
        Resist = 4,
        Massive = 5
    }
    public enum RarityTypes
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
        byte type;
        byte grade;
        public TalentOrb(byte type, byte grade)
        {
            this.type = type;
            this.grade = grade;
        }
    }
    public class Unit
    {
        //Handles both regular and + levels.
        public Vector2 Level;
        public byte[] LevelCurve;
        public byte Rarity;
        public string Name;
        public List<UnitFormBlueprint> Forms;


    }
}
