using System;
using GXPEngine.Core;
using GXPEngine.OpenGL;
namespace GXPEngine

{ //całość jest kkopiuj i wklej z assigmentu, dodane są tylko punkty
	public class LineSegment : GameObject
	{
		public Vec2 start;
		public Vec2 end;

		public uint color = 0xffffffff;
		public uint lineWidth = 4;

		public float points;

		public LineSegment(float pStartX, float pStartY, float pEndX, float pEndY, float pPoints, uint pColor = 0xffffffff, uint pLineWidth = 4)
			: this(new Vec2(pStartX, pStartY), new Vec2(pEndX, pEndY), pPoints, pColor, pLineWidth)
		{
		}

		public LineSegment(Vec2 pStart, Vec2 pEnd, float pPoints, uint pColor = 0xffffffff, uint pLineWidth = 4)
		{
			start = pStart;
			end = pEnd;
			color = pColor;
			lineWidth = pLineWidth;
			points = pPoints;

		}

		override protected void RenderSelf(GLContext glContext)
		{
			if (game != null)
			{
				Gizmos.RenderLine(start.x, start.y, end.x, end.y, color, lineWidth);
			}
		}
	}
}

