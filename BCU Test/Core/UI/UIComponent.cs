using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using BCU_Test;
using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BCU_Test.Core.UI
{
    public abstract class UIComponent
    {
        /// <summary>
        /// The offset (x,y) and size (z,w) of the component, values spanning [0, 1].
        /// This span represents the relative span compared to either the parent window/component.
        /// </summary>
        private Vector4 RelativeSpace;

        /// <summary>The actual effective offset and size of the component, in pixels.</summary>
        public Rectangle PixelSpace { get; private set; }
        /// <summary>
        /// Used to determine which component will be activated by a click in the event there are multiple covering an area.
        /// </summary>
        public byte Height { get; private init; }
        /// <summary>The designated anchor point for the component compared to its parent, values span [0, 1].</summary>
        public Vector2 AnchorPoint { get; private set; }

        /// <summary>Determines if this component will be visible.</summary>
        public bool Hidden { get; set; }

        /// <summary>Determines whether the component will be active. Defaults to false when the component is Hidden.</summary>
        public bool Enabled { get; private set; }

        /// <summary>All the possible children that this component can have.</summary>
        public List<UIComponent> Children { get; private set; }
        public UIComponent? Parent { get; private init; }
        public Panel HomePanel { get; private init; }
        /// <summary>Desired texture for this component. Doesn't have to be set.</summary>
        public Texture2D? Texture { get; private set; }
        public Vector2 Scale { get; private set; }
        public Color viewColor { get; private set; }
        public Task WatchThread { get; private set; }


        public void SetVals(Vector2 anchorPoint, Vector4 designSpace)
        {
            Hidden = false;
            Enabled = true;
            Scale = Vector2.One;
            viewColor = Color.White;
            AnchorPoint = anchorPoint;
            RelativeSpace = designSpace;

            if(Parent != null)
                SetPixelSpaceFromComponent();
            else
                SetPixelSpaceFromPanel();

            Children = new List<UIComponent>();
        }
        public UIComponent(Panel panel, Vector2 anchorPoint, Vector4 designSpace)
        {
            HomePanel = panel;
            SetVals(anchorPoint, designSpace);
        }
        public UIComponent(UIComponent parent, Vector2 anchorPoint, Vector4 designSpace)
        {
            Parent = parent;
            Parent.AddChild(this);
            HomePanel = Parent.HomePanel;
            SetVals(anchorPoint, designSpace);
        }
        public void ToggleHidden(bool? newState = null)
        {
            Hidden = newState != null ? newState.Value : !Hidden;
            Enabled = Hidden ? false : Enabled;

            foreach(UIComponent child in Children)
                child.ToggleHidden(newState);
        }
        public void ToggleEnabled(bool? newState = null)
        {
            Enabled = Hidden ? false : (newState != null ? newState.Value : !Enabled);

            foreach (UIComponent child in Children)
                child.ToggleEnabled(newState);
        }
        public void AddChild(UIComponent newChild)
        {
            Children.Add(newChild);
        }
        public void OnResize()
        {
            if (Parent == null)
                SetPixelSpaceFromPanel();
            else
                SetPixelSpaceFromComponent();

            foreach(UIComponent child in Children)
                child.OnResize();
        }
        private void SetPixelSpaceFromPanel()
        {
            Point panelSize = HomePanel.Window.ClientBounds.Size;
            Point pixelPos = new Point((panelSize.X*(AnchorPoint.X + RelativeSpace.X*Scale.X)).AutoRound()
                                      ,(panelSize.Y*(AnchorPoint.Y + RelativeSpace.Y*Scale.Y)).AutoRound());

            Point pixelSize = new Point((panelSize.X*RelativeSpace.Z).AutoRound(),(panelSize.Y*RelativeSpace.Z).AutoRound());
            PixelSpace = new Rectangle(pixelPos, pixelSize);
        }
        private void SetPixelSpaceFromComponent()
        {
            Rectangle ParentPixelSpace = Parent.PixelSpace;
            Point pixelPos = ParentPixelSpace.Location +
                new Point((ParentPixelSpace.X*AnchorPoint.X + ParentPixelSpace.Width*RelativeSpace.X*Scale.X).AutoRound(),
                    (ParentPixelSpace.Y*AnchorPoint.Y + ParentPixelSpace.Height*RelativeSpace.Y*Scale.Y).AutoRound());


            Point pixelSize = new Point((ParentPixelSpace.Width*RelativeSpace.Y*Scale.X).AutoRound(),
                                        (ParentPixelSpace.Height*RelativeSpace.W*Scale.Y).AutoRound());
            PixelSpace = new Rectangle(pixelPos, pixelSize);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawOpenRectangle(PixelSpace, Color.Black);
        }
        public virtual void OnMousePress(bool right)
        {
            return;
        }
        public virtual void OnMouseRelease(bool right)
        {
            return;
        }
        public virtual void OnKeyPress(Keys[] keys)
        {
            return;
        }
        public virtual void OnKeyRelease(Keys[] keys)
        {
            return;
        }
    }
}
