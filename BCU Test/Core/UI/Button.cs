using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCU_Test.Core.UI
{
    internal class Button : UIComponent
    {
        private string _text;
        public Button(Panel panel, Vector2 anchorPoint, Vector4 designSpace) : base(panel, anchorPoint, designSpace)
        { }
        public Button(UIComponent parent, Vector2 anchorPoint, Vector4 designSpace) : base(parent, anchorPoint, designSpace)
        { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawOpenRectangle(PixelSpace, Color.Black);
        }
    }
}
