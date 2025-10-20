using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

namespace BCU_Test.Core.Graphics
{
    struct ModelPart
    {
        public int PartId;
        public int ParentId;
        public int SpriteId;
        public List<int> ChildrenIds;
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
            Glows = args[12] > 0 ? true : false;
            Name = name;
        }
        public ModelPart DeepCopy()
        {
            int[] Transfer = { PartId, ParentId, SpriteId, ZOrder,
                (int)Position.X, (int)Position.Y, (int)Pivot.X, (int)Pivot.Y,
                (int)Scale.X, (int)Scale.Y, (int)Angle, (int)Opacity, Glows ? 1 : 0 };
            ModelPart copy = new ModelPart(Transfer, Name);
            copy.ChildrenIds = [..ChildrenIds];//Today, April 29th 2025, I learned of the Range Operator. Cool.
            return copy;
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
        static string[] DefaultAnims = ["Walk", "Idle", "Attack", "KnockBack"];
        public int SelfId; //TODO: implement these when I implement the id systems for this.
        List<ModelPart> Parts;
        List<int> DrawOrder;
        Dictionary<string, EntityAnimation> Anims;
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
            EntityModel model = new EntityModel();
            model.SpriteSheet = ImageCutSheet.CreateImageCutSheet();
            foreach(string def in DefaultAnims)
            {
                EntityAnimation newAnim = EntityAnimation.NewAnimation();
                newAnim.AnimName = def;
                model.Anims.Add(def, newAnim);
            }
            return model;
        }
        public static EntityModel FromFile(string PathToFolder)
        {
            EntityModel model = new EntityModel();
            model.SpriteSheet = ImageCutSheet.FromFile(PathToFolder);
            using(StreamReader sr = new(PathToFolder+"/mamodel.txt"))
            {
                //The original java code seems to do something similar regarding handling the first 3 lines,
                //the first line seems to be the identifier for what the file is, 
                for (int silly = 0; silly < 2; silly++)
                    sr.ReadLine();

                int PartNumber = int.Parse(sr.ReadLine().Trim());
                for(int i = 0; i < PartNumber; i++)
                    model.Parts.Add(ModelPart.FromFileLine(sr.ReadLine().Trim()));

                string[] standards = sr.ReadLine().Trim().Split(',');
                for(int s = 0; s < 3; s++)
                {
                    int standard = int.Parse(standards[s]);
                    if (model.Standards[s] != standard) { model.Standards[s] = standard; }
                }
            }
            return model;
        }
        public EntityModel DeepCopy()
        {
            EntityModel newModel = new EntityModel();
            newModel.SpriteSheet = SpriteSheet.DeepCopy();

            newModel.Parts = [];
            foreach (ModelPart i in Parts)
                newModel.Parts.Add(i.DeepCopy());

            newModel.Standards = [];
            for(int i = 0; i < Standards.Length; i++)
                newModel.Standards[i] = Standards[i];

            newModel.DrawOrder = [];
            foreach(int i in DrawOrder)
                newModel.DrawOrder.Add(i);

            newModel.Anims = new Dictionary<string, EntityAnimation>();
            foreach (KeyValuePair<string, EntityAnimation> anim in Anims)
                newModel.Anims.Add(anim.Key, anim.Value.DeepCopy());

            return newModel;
        }
        public void AddPart() => Parts.Add(ModelPart.Default(Parts.Count));
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
