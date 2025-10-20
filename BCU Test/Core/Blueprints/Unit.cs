using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    public enum RarityType
    {
        Normal = 0,
        EX = 1,
        Rare = 2,
        SuperRare = 3,
        UberRare = 4,
        LegendRare = 5
    }
    internal class Unit
    {
        //TODO: Implement ID when I begin working on ID systems.
        public string Source { get; private init; }
        public short UnitId { get; private set; } //If anyone gets over 32k unit types in their database, it'd be surprising to say the least.
        public byte[] LevelCurve;
        public Vector2 MaxLevel; //Handles both XP-bought levels and +levels. : 3
        public RarityType Rarity;
        public string Name;
        public List<FormBlueprint> Forms;
        public byte ChosenForm; //If anyone manages to get more than 256 forms in a single unit I'll be damn well surprised.

        public Unit(FormBlueprint initialForm)
        {
            Rarity = RarityType.UberRare;

            MaxLevel = new(50, 0);
            Name = "New Unit";
            Forms = [initialForm];
            ChosenForm = 0;
        }
        public void AddForm(FormBlueprint formToAdd)
        {
            Forms.Add(formToAdd);
        }
    }
}
