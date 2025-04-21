using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Graphics
{
    struct ModelPart
    {
        public int PartId;
        public int ParentId;
        public int SpriteId;
        public int ZOrder;
        public Vector2 Position;
        public Vector2 Pivot;
        public Vector2 Scale;
        public float Angle;
        public float Opacity;
        public bool Glows;
        public string Name;
        public static ModelPart Default(int id)
        {
            int[] Standard = {id, 0, 0, 0, 0, 0, 0, 0, 1000, 1000, 0, 1000, 0};
            return new ModelPart(Standard, "");
        }
        public ModelPart(int[] args, string name)
        {
            PartId = args[0];
            ParentId = args[1];
            SpriteId = args[2];
            ZOrder = args[3];
            Position = new(args[4], args[5]);
            Pivot = new(args[6], args[7]);
            Scale = new(args[8], args[9]);
            Angle = args[10];
            Opacity = args[11];
            Glows = args[12] == 1 ? true : false;
            Name = name;
        }
        public ModelPart DeepCopy()
        {
            int[] Transfer = {PartId, ParentId, SpriteId, ZOrder,
                (int)Position.X, (int)Position.Y, (int)Pivot.X, (int)Pivot.Y,
                (int)Scale.X, (int)Scale.Y, (int)Angle, (int)Opacity, Glows ? 1 : 0};
            return new ModelPart(Transfer, Name);
        }
        public static ModelPart FromFileLine(string argument)
        {
            string[] args = argument.Split(',');
            int i = 0;
            int tempOutput = 0;
            List<int> extracts = new List<int>();
            while (int.TryParse(args[i], out tempOutput))
            {
                i++;
                extracts.Add(tempOutput);
            }
            return new ModelPart(extracts.ToArray(), args[i]);
        }
    }
    public class EntityModel
    {
        List<ModelPart> Parts;
        List<int> DrawOrder;
        ImageCutSheet SpriteSheet;
        int[] Standards;
        private EntityModel()
        {
            Parts = new List<ModelPart>();
            DrawOrder = new List<int>();
            Standards = [1000, 3600, 1000];
        }
        public static EntityModel NewModel()
        {
            return new EntityModel();
        }
        public static EntityModel FromFile(string Path)
        {
            EntityModel model = new EntityModel();
            using(StreamReader sr = new(Path+"/mamodel.txt"))
            {
                //The original java code seems to do something similar regarding handling the first 3 lines,
                //not sure what they do or exist for.
                for (int silly = 0; silly < 2; silly++) { sr.ReadLine(); }
                int PartNumber = int.Parse(sr.ReadLine().Trim());
                for(int i = 0; i < PartNumber; i++)
                {
                    model.Parts.Add(ModelPart.FromFileLine(sr.ReadLine().Trim()));
                }
                string[] standards = sr.ReadLine().Trim().Split(',');
                for(int s = 0; s < 3; s++)
                {
                    int standard = int.Parse(standards[s]);
                    if (model.Standards[s] != standard) { model.Standards[s] = standard; }
                }
            }
            return model;
        }
        public void AddPart()
        {
            Parts.Add(ModelPart.Default(Parts.Count));
        }
        public void Mirror()
        {
            if (Parts.Count > 1)
            {
                ModelPart temp = Parts[0];
                temp.Scale.X *= -1;
                temp.Angle *= -1;
                for (int i = 1; i < Parts.Count; i++)
                {
                    temp = Parts[i];
                    temp.Angle *= -1;
                }
            }
        }
    }
}
