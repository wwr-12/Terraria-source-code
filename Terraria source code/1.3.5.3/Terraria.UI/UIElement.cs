using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;

namespace Terraria.UI
{
	public class UIElement : IComparable
	{
		public delegate void MouseEvent(UIMouseEvent evt, UIElement listeningElement);

		public delegate void ScrollWheelEvent(UIScrollWheelEvent evt, UIElement listeningElement);

		public string Id = "";

		public UIElement Parent;

		protected List<UIElement> Elements = new List<UIElement>();

		public StyleDimension Top;

		public StyleDimension Left;

		public StyleDimension Width;

		public StyleDimension Height;

		public StyleDimension MaxWidth = StyleDimension.Fill;

		public StyleDimension MaxHeight = StyleDimension.Fill;

		public StyleDimension MinWidth = StyleDimension.Empty;

		public StyleDimension MinHeight = StyleDimension.Empty;

		private bool _isInitialized;

		public bool OverflowHidden;

		public float PaddingTop;

		public float PaddingLeft;

		public float PaddingRight;

		public float PaddingBottom;

		public float MarginTop;

		public float MarginLeft;

		public float MarginRight;

		public float MarginBottom;

		public float HAlign;

		public float VAlign;

		private CalculatedStyle _innerDimensions;

		private CalculatedStyle _dimensions;

		private CalculatedStyle _outerDimensions;

		private static RasterizerState _overflowHiddenRasterizerState;

		protected bool _useImmediateMode;

		private SnapPoint _snapPoint;

		private bool _isMouseHovering;

		public bool IsMouseHovering => _isMouseHovering;

		public event MouseEvent OnMouseDown;

		public event MouseEvent OnMouseUp;

		public event MouseEvent OnClick;

		public event MouseEvent OnMouseOver;

		public event MouseEvent OnMouseOut;

		public event MouseEvent OnDoubleClick;

		public event ScrollWheelEvent OnScrollWheel;

		public UIElement()
		{
			if (_overflowHiddenRasterizerState == null)
			{
				_overflowHiddenRasterizerState = new RasterizerState
				{
					CullMode = CullMode.None,
					ScissorTestEnable = true
				};
			}
		}

		public void SetSnapPoint(string name, int id, Vector2? anchor = null, Vector2? offset = null)
		{
			if (!anchor.HasValue)
			{
				anchor = new Vector2(0.5f);
			}
			if (!offset.HasValue)
			{
				offset = Vector2.Zero;
			}
			_snapPoint = new SnapPoint(name, id, anchor.Value, offset.Value);
		}

		public bool GetSnapPoint(out SnapPoint point)
		{
			point = _snapPoint;
			if (_snapPoint != null)
			{
				_snapPoint.Calculate(this);
			}
			return _snapPoint != null;
		}

		protected virtual void DrawSelf(SpriteBatch spriteBatch)
		{
		}

		protected virtual void DrawChildren(SpriteBatch spriteBatch)
		{
			foreach (UIElement element in Elements)
			{
				element.Draw(spriteBatch);
			}
		}

		public void Append(UIElement element)
		{
			element.Remove();
			element.Parent = this;
			Elements.Add(element);
			element.Recalculate();
		}

		public void Remove()
		{
			if (Parent != null)
			{
				Parent.RemoveChild(this);
			}
		}

		public void RemoveChild(UIElement child)
		{
			Elements.Remove(child);
			child.Parent = null;
		}

		public void RemoveAllChildren()
		{
			foreach (UIElement element in Elements)
			{
				element.Parent = null;
			}
			Elements.Clear();
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			bool overflowHidden = OverflowHidden;
			bool useImmediateMode = _useImmediateMode;
			RasterizerState rasterizerState = spriteBatch.GraphicsDevice.RasterizerState;
			Rectangle scissorRectangle = spriteBatch.GraphicsDevice.ScissorRectangle;
			SamplerState anisotropicClamp = SamplerState.AnisotropicClamp;
			if (useImmediateMode)
			{
				spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, _overflowHiddenRasterizerState, null, Main.UIScaleMatrix);
				DrawSelf(spriteBatch);
				spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, _overflowHiddenRasterizerState, null, Main.UIScaleMatrix);
			}
			else
			{
				DrawSelf(spriteBatch);
			}
			if (overflowHidden)
			{
				spriteBatch.End();
				Rectangle clippingRectangle = GetClippingRectangle(spriteBatch);
				spriteBatch.GraphicsDevice.ScissorRectangle = clippingRectangle;
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, _overflowHiddenRasterizerState, null, Main.UIScaleMatrix);
			}
			DrawChildren(spriteBatch);
			if (overflowHidden)
			{
				spriteBatch.End();
				spriteBatch.GraphicsDevice.ScissorRectangle = scissorRectangle;
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, rasterizerState, null, Main.UIScaleMatrix);
			}
		}

		public virtual void Update(GameTime gameTime)
		{
			foreach (UIElement element in Elements)
			{
				element.Update(gameTime);
			}
		}

		public Rectangle GetClippingRectangle(SpriteBatch spriteBatch)
		{
			Vector2 vector = new Vector2(_innerDimensions.X, _innerDimensions.Y);
			Vector2 position = new Vector2(_innerDimensions.Width, _innerDimensions.Height) + vector;
			vector = Vector2.Transform(vector, Main.UIScaleMatrix);
			position = Vector2.Transform(position, Main.UIScaleMatrix);
			Rectangle result = new Rectangle((int)vector.X, (int)vector.Y, (int)(position.X - vector.X), (int)(position.Y - vector.Y));
			int width = spriteBatch.GraphicsDevice.Viewport.Width;
			int height = spriteBatch.GraphicsDevice.Viewport.Height;
			result.X = Utils.Clamp(result.X, 0, width);
			result.Y = Utils.Clamp(result.Y, 0, height);
			result.Width = Utils.Clamp(result.Width, 0, width - result.X);
			result.Height = Utils.Clamp(result.Height, 0, height - result.Y);
			return result;
		}

		public virtual List<SnapPoint> GetSnapPoints()
		{
			List<SnapPoint> list = new List<SnapPoint>();
			if (GetSnapPoint(out var point))
			{
				list.Add(point);
			}
			foreach (UIElement element in Elements)
			{
				list.AddRange(element.GetSnapPoints());
			}
			return list;
		}

		public virtual void Recalculate()
		{
			CalculatedStyle calculatedStyle = ((Parent == null) ? UserInterface.ActiveInstance.GetDimensions() : Parent.GetInnerDimensions());
			if (Parent != null && Parent is UIList)
			{
				calculatedStyle.Height = float.MaxValue;
			}
			CalculatedStyle calculatedStyle2 = default(CalculatedStyle);
			calculatedStyle2.X = Left.GetValue(calculatedStyle.Width) + calculatedStyle.X;
			calculatedStyle2.Y = Top.GetValue(calculatedStyle.Height) + calculatedStyle.Y;
			float value = MinWidth.GetValue(calculatedStyle.Width);
			float value2 = MaxWidth.GetValue(calculatedStyle.Width);
			float value3 = MinHeight.GetValue(calculatedStyle.Height);
			float value4 = MaxHeight.GetValue(calculatedStyle.Height);
			calculatedStyle2.Width = MathHelper.Clamp(Width.GetValue(calculatedStyle.Width), value, value2);
			calculatedStyle2.Height = MathHelper.Clamp(Height.GetValue(calculatedStyle.Height), value3, value4);
			calculatedStyle2.Width += MarginLeft + MarginRight;
			calculatedStyle2.Height += MarginTop + MarginBottom;
			calculatedStyle2.X += calculatedStyle.Width * HAlign - calculatedStyle2.Width * HAlign;
			calculatedStyle2.Y += calculatedStyle.Height * VAlign - calculatedStyle2.Height * VAlign;
			_outerDimensions = calculatedStyle2;
			calculatedStyle2.X += MarginLeft;
			calculatedStyle2.Y += MarginTop;
			calculatedStyle2.Width -= MarginLeft + MarginRight;
			calculatedStyle2.Height -= MarginTop + MarginBottom;
			_dimensions = calculatedStyle2;
			calculatedStyle2.X += PaddingLeft;
			calculatedStyle2.Y += PaddingTop;
			calculatedStyle2.Width -= PaddingLeft + PaddingRight;
			calculatedStyle2.Height -= PaddingTop + PaddingBottom;
			_innerDimensions = calculatedStyle2;
			RecalculateChildren();
		}

		public UIElement GetElementAt(Vector2 point)
		{
			UIElement uIElement = null;
			foreach (UIElement element in Elements)
			{
				if (element.ContainsPoint(point))
				{
					uIElement = element;
					break;
				}
			}
			if (uIElement != null)
			{
				return uIElement.GetElementAt(point);
			}
			if (ContainsPoint(point))
			{
				return this;
			}
			return null;
		}

		public virtual bool ContainsPoint(Vector2 point)
		{
			if (point.X > _dimensions.X && point.Y > _dimensions.Y && point.X < _dimensions.X + _dimensions.Width)
			{
				return point.Y < _dimensions.Y + _dimensions.Height;
			}
			return false;
		}

		public void SetPadding(float pixels)
		{
			PaddingBottom = pixels;
			PaddingLeft = pixels;
			PaddingRight = pixels;
			PaddingTop = pixels;
		}

		public virtual void RecalculateChildren()
		{
			foreach (UIElement element in Elements)
			{
				element.Recalculate();
			}
		}

		public CalculatedStyle GetInnerDimensions()
		{
			return _innerDimensions;
		}

		public CalculatedStyle GetDimensions()
		{
			return _dimensions;
		}

		public CalculatedStyle GetOuterDimensions()
		{
			return _outerDimensions;
		}

		public void CopyStyle(UIElement element)
		{
			Top = element.Top;
			Left = element.Left;
			Width = element.Width;
			Height = element.Height;
			PaddingBottom = element.PaddingBottom;
			PaddingLeft = element.PaddingLeft;
			PaddingRight = element.PaddingRight;
			PaddingTop = element.PaddingTop;
			HAlign = element.HAlign;
			VAlign = element.VAlign;
			MinWidth = element.MinWidth;
			MaxWidth = element.MaxWidth;
			MinHeight = element.MinHeight;
			MaxHeight = element.MaxHeight;
			Recalculate();
		}

		public virtual void MouseDown(UIMouseEvent evt)
		{
			if (this.OnMouseDown != null)
			{
				this.OnMouseDown(evt, this);
			}
			if (Parent != null)
			{
				Parent.MouseDown(evt);
			}
		}

		public virtual void MouseUp(UIMouseEvent evt)
		{
			if (this.OnMouseUp != null)
			{
				this.OnMouseUp(evt, this);
			}
			if (Parent != null)
			{
				Parent.MouseUp(evt);
			}
		}

		public virtual void MouseOver(UIMouseEvent evt)
		{
			_isMouseHovering = true;
			if (this.OnMouseOver != null)
			{
				this.OnMouseOver(evt, this);
			}
			if (Parent != null)
			{
				Parent.MouseOver(evt);
			}
		}

		public virtual void MouseOut(UIMouseEvent evt)
		{
			_isMouseHovering = false;
			if (this.OnMouseOut != null)
			{
				this.OnMouseOut(evt, this);
			}
			if (Parent != null)
			{
				Parent.MouseOut(evt);
			}
		}

		public virtual void Click(UIMouseEvent evt)
		{
			if (this.OnClick != null)
			{
				this.OnClick(evt, this);
			}
			if (Parent != null)
			{
				Parent.Click(evt);
			}
		}

		public virtual void DoubleClick(UIMouseEvent evt)
		{
			if (this.OnDoubleClick != null)
			{
				this.OnDoubleClick(evt, this);
			}
			if (Parent != null)
			{
				Parent.DoubleClick(evt);
			}
		}

		public virtual void ScrollWheel(UIScrollWheelEvent evt)
		{
			if (this.OnScrollWheel != null)
			{
				this.OnScrollWheel(evt, this);
			}
			if (Parent != null)
			{
				Parent.ScrollWheel(evt);
			}
		}

		public void Activate()
		{
			if (!_isInitialized)
			{
				Initialize();
			}
			OnActivate();
			foreach (UIElement element in Elements)
			{
				element.Activate();
			}
		}

		public virtual void OnActivate()
		{
		}

		public void Deactivate()
		{
			OnDeactivate();
			foreach (UIElement element in Elements)
			{
				element.Deactivate();
			}
		}

		public virtual void OnDeactivate()
		{
		}

		public void Initialize()
		{
			OnInitialize();
			_isInitialized = true;
		}

		public virtual void OnInitialize()
		{
		}

		public virtual int CompareTo(object obj)
		{
			return 0;
		}
	}
}
