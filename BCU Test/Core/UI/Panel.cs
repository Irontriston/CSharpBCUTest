using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BCU_Test.Core.UI
{
    public class Panel
    {
        public GameWindow Window { get; private set; }
        public bool Hidden { get; private set; }
        public bool Enabled { get; private set; }
        public List<UIComponent> Children { get; private set; }
        /// <summary>
        /// A special dictionary that holds lists of Components based on layer. The larger the byte, the higher the components are relative to every other component.
        /// </summary>
        private Dictionary<byte, List<UIComponent>> Members;

        public Panel(GameWindow window)
        {
            Window = window;
            Hidden = false;
            Enabled = true;
            Children = new List<UIComponent>();
            Members = new Dictionary<byte, List<UIComponent>>();
        }
        public void ToggleHidden(bool? newState = null)
        {
            Hidden = newState != null ? newState.Value : !Hidden;
            Enabled = Hidden ? Hidden : Enabled;

            foreach(UIComponent member in Children)
                member.ToggleHidden(newState);
        }
        public void ToggleEnabled(bool? newState = null)
        {
            Enabled = Hidden ? false : (newState != null ? newState.Value : !Enabled);

            foreach(UIComponent member in Children)
                member.ToggleEnabled(newState);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (byte i = 0; i < Members.Count; i++)
            {
                foreach (UIComponent member in Members[i])
                    member.Draw(spriteBatch);
            }
        }
        public void OnWindowResize()
        {
            foreach(UIComponent member in Children)
                member.OnResize();
        }
        public void AddComponentMember(UIComponent member, byte heightOrder)
        {
            if(Members.ContainsKey(heightOrder))
                Members[heightOrder].Add(member);
            else
                Members[heightOrder] = [member];
        }
        public void RemoveComponentMember(UIComponent member)
        {
            for(byte i = 0; i < Members.Count; i++)
            {
                if (Members[i].Contains(member))
                {
                    Members[i].Remove(member);
                    if (Members[i].Count < 1)
                        Members.Remove(i);
                    break;
                }
            }
        }
        private UIComponent FindActiveComponent(Vector2 mousePos)
        {
            for (byte i = (byte)(Members.Count - 1); i >= 0; i--)
            {
                foreach(UIComponent member in Members[i])
                {
                    if (member.PixelSpace.Contains(mousePos))
                        return member;
                }
            }
            return null;
        }
        public void OnMousePress(Vector2 mousePos, bool right)
        {
            FindActiveComponent(mousePos).OnMousePress(right);
        }
        public void OnMouseRelease(Vector2 mousePos, bool right)
        {
            FindActiveComponent(mousePos).OnMouseRelease(right);
        }
        public virtual void OnKeyPress(Keys[] keys)
        {
            return;
        }
    }
}
