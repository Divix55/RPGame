using System;
namespace RPGame
{
	public class Animation
	{
		public int offSetTop;
		public int offSetLeft;
		public int numFrames;

		public Animation(int offSetTop, int offSetLeft, int numFrames)
		{
			this.offSetTop = offSetTop;
			this.offSetLeft = offSetLeft;
			this.numFrames = numFrames;
		}
	}
}

