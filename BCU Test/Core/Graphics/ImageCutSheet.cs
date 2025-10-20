using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace BCU_Test.Core.Graphics
{
    struct ImageCut
    {
        Rectangle Area;
        string Name;
        public ImageCut(int[] RectArray, string name)
        {
            Area = new(RectArray[0], RectArray[1], RectArray[2], RectArray[3]);
            Name = name;
        }
        public static ImageCut Default()
        {
            return new ImageCut(new int[] { 0, 0, 1, 1 }, "Default");
        }
        public ImageCut DeepCopy()
        {
            return new ImageCut(new int[] { Area.X, Area.Y, Area.Width, Area.Height }, (string)Name.Clone());
        }
    }
    class ImageCutSheet
    {
        public string Name;
        Texture2D SpriteSheet { get; set; }
        public List<ImageCut> Cuts;

        //todo: Make this contructor add all the other files associated with the anims.
        private ImageCutSheet(Texture2D spriteSheet)
        {
            SpriteSheet = spriteSheet;
            Cuts = new List<ImageCut>();
        }
        public static ImageCutSheet CreateImageCutSheet()
        {
            return new ImageCutSheet(new Texture2D(BattleCatsUltimate.Instance.GraphicsDevice, 4, 4));
        }
        public static ImageCutSheet FromFile(string PathToFolder)
        {
            ImageCutSheet imgCutSheet = new ImageCutSheet(Texture2D.FromFile(BattleCatsUltimate.Instance.GraphicsDevice,PathToFolder + "/sprite.png"));
            using (StreamReader sr = new(PathToFolder + "/imgcut.txt"))
            {
                //There's an awful lot of skipping lines that's going on here.
                for(int silly = 0; silly < 2; silly++) { sr.ReadLine(); }
                string? line = sr.ReadLine().Trim();
                imgCutSheet.Name = line == null ? "" : line;
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    string[] constructors = sr.ReadLine().Trim().Split(',');
                    int[] ints = new int[4];
                    for (int i = 0; i < 4; i++)
                    {
                        ints[i] = int.Parse(constructors[i]);
                    }
                    //Bc I don't know how C# handles comma separators that lead to nothing, this is a failsafe to ensure there's always a value.
                    string name = constructors.Length > 4 ? constructors[4] : "";
                    imgCutSheet.Cuts.Add(new ImageCut(ints, name));
                }
            }
            return imgCutSheet;
        }
        public ImageCutSheet DeepCopy()
        {
            ImageCutSheet ImgCutSheet = new ImageCutSheet((Texture2D)SpriteSheet.Clone());
            ImgCutSheet.Cuts = [];
            foreach(ImageCut i in Cuts)
                ImgCutSheet.Cuts.Add(i.DeepCopy());

            return ImgCutSheet;
        }
        public void DrawPart(Vector2 Position, Vector2 Pivot, Vector2 Scale, double opacity, bool Glow)
        {

        }
    }
}
