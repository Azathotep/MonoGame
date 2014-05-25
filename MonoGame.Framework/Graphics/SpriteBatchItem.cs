using System;

namespace Microsoft.Xna.Framework.Graphics
{
	internal class SpriteBatchItem
	{
		public Texture2D Texture;
		public float Depth;

        public VertexPositionColorTexture vertexTL;
		public VertexPositionColorTexture vertexTR;
		public VertexPositionColorTexture vertexBL;
		public VertexPositionColorTexture vertexBR;
		public SpriteBatchItem ()
		{
			vertexTL = new VertexPositionColorTexture();
            vertexTR = new VertexPositionColorTexture();
            vertexBL = new VertexPositionColorTexture();
            vertexBR = new VertexPositionColorTexture();            
		}
		
		public void Set ( float x, float y, float w, float h, Color color, Vector2 texCoordTL, Vector2 texCoordBR )
		{
			vertexTL.Position.X = x;
            vertexTL.Position.Y = y;
            vertexTL.Position.Z = Depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;            

			vertexTR.Position.X = x+w;
            vertexTR.Position.Y = y;
            vertexTR.Position.Z = Depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

			vertexBL.Position.X = x;
            vertexBL.Position.Y = y+h;
            vertexBL.Position.Z = Depth;
            vertexBL.Color = color;
			vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

			vertexBR.Position.X = x+w;
            vertexBR.Position.Y = y+h;
            vertexBR.Position.Z = Depth;
            vertexBR.Color = color;
			vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
		}

		public void Set (float x, float y, float dx, float dy, float w, float h, float sin, float cos, Color color, Vector2 texCoordTL, Vector2 texCoordBR )
		{
            // TODO, Should we be just assigning the Depth Value to Z?
            // According to http://blogs.msdn.com/b/shawnhar/archive/2011/01/12/spritebatch-billboards-in-a-3d-world.aspx
            // We do.
			vertexTL.Position.X = x+dx*cos-dy*sin;
            vertexTL.Position.Y = y+dx*sin+dy*cos;
            vertexTL.Position.Z = Depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

			vertexTR.Position.X = x+(dx+w)*cos-dy*sin;
            vertexTR.Position.Y = y+(dx+w)*sin+dy*cos;
            vertexTR.Position.Z = Depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

			vertexBL.Position.X = x+dx*cos-(dy+h)*sin;
            vertexBL.Position.Y = y+dx*sin+(dy+h)*cos;
            vertexBL.Position.Z = Depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

			vertexBR.Position.X = x+(dx+w)*cos-(dy+h)*sin;
            vertexBR.Position.Y = y+(dx+w)*sin+(dy+h)*cos;
            vertexBR.Position.Z = Depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
		}

        public void Set(Vector2 topLeft, Vector2 topRight, Vector2 bottomLeft, Vector2 bottomRight, float dx, float dy, float sin, float cos, Color color, Vector2 texCoordTL, Vector2 texCoordBR)
        {
            // TODO, Should we be just assigning the Depth Value to Z?
            // According to http://blogs.msdn.com/b/shawnhar/archive/2011/01/12/spritebatch-billboards-in-a-3d-world.aspx
            // We do.
            vertexTL.Position.X = topLeft.X + dx * cos - dy * sin;
            vertexTL.Position.Y = topLeft.Y + dx * sin + dy * cos;
            vertexTL.Position.Z = Depth;
            vertexTL.Color = color;
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

            vertexTR.Position.X = topLeft.X + ((topRight.X - topLeft.X) + dx) * cos - (dy + (topRight.Y - topLeft.Y)) * sin;
            vertexTR.Position.Y = topLeft.Y + ((topRight.X - topLeft.X) + dx) * sin + (dy + (topRight.Y - topLeft.Y)) * cos;
            vertexTR.Position.Z = Depth;
            vertexTR.Color = color;
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

            vertexBL.Position.X = topLeft.X + ((bottomLeft.X - topLeft.X) + dx) * cos - (dy + (bottomLeft.Y - topLeft.Y)) * sin;
            vertexBL.Position.Y = topLeft.Y + ((bottomLeft.X - topLeft.X) + dx) * sin + (dy + (bottomLeft.Y - topLeft.Y)) * cos;
            vertexBL.Position.Z = Depth;
            vertexBL.Color = color;
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

            vertexBR.Position.X = topLeft.X + ((bottomRight.X - topLeft.X) + dx) * cos - (dy + (bottomRight.Y - topLeft.Y)) * sin;
            vertexBR.Position.Y = topLeft.Y + ((bottomRight.X - topLeft.X) + dx) * sin + (dy + (bottomRight.Y - topLeft.Y)) * cos;
            vertexBR.Position.Z = Depth;
            vertexBR.Color = color;
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
        }
	}
}

