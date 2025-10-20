using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCU_Test.Core.UI
{
    internal class Viewbox : UIComponent
    {
        public Color BackGroundColor { get; private set; }
        public Viewbox(Panel panel, Vector2 anchorPoint, Vector4 designSpace) : base(panel, anchorPoint, designSpace)
        {
            BackGroundColor = Color.White;
        }
        public Viewbox(UIComponent parent, Vector2 anchorPoint, Vector4 designSpace) : base(parent, anchorPoint, designSpace)
        {
            BackGroundColor = Color.White;
        }
        public void SetBackGroundColor(Color newColor)
        {
            BackGroundColor = newColor;
        }


    }
}
