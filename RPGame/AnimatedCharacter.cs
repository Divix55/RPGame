using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
	public enum CharacterState
	{
		None,
		MovingUp,
		MovingLeft,
		MovingDown,
		MovingRight
	}
	public abstract class AnimatedCharacter
	{
		public float xpos { get; set; }
		public float ypos { get; set; }

		private Sprite sprite;
		private IntRect spriteRect;
		private int frameSize;

		public CharacterState CurrentState { get; set; }

		protected Animation Anim_Up;
		protected Animation Anim_Left;
		protected Animation Anim_Down;
		protected Animation Anim_Right;

		private Clock animationClock;
		protected float moveSpeed = 50;
		protected float animationSpeed = 0.1f;

		public AnimatedCharacter(string filename, int frameSize)
		{
			this.frameSize = frameSize;
			Texture texture = new Texture(filename);

			spriteRect = new IntRect(0, 0, frameSize, frameSize);
			sprite = new Sprite(texture, spriteRect);



			animationClock = new Clock();
		}

		public virtual void Update(float deltaTime)
		{
			Animation currentAnimation = null;

			switch (CurrentState)
			{
				case CharacterState.MovingUp:
					currentAnimation = Anim_Up;
					ypos -= moveSpeed * deltaTime;
					break;
				case CharacterState.MovingLeft:
					currentAnimation = Anim_Left;
					xpos -= moveSpeed * deltaTime;
					break;
				case CharacterState.MovingDown:
					currentAnimation = Anim_Down;
					ypos += moveSpeed * deltaTime;
					break;
				case CharacterState.MovingRight:
					currentAnimation = Anim_Right;
					xpos += moveSpeed * deltaTime;
					break;
			}
			sprite.Position = new Vector2f(xpos, ypos);

			if (animationClock.ElapsedTime.AsSeconds() > animationSpeed)
			{
				if (currentAnimation != null)
				{
					spriteRect.Top = currentAnimation.offSetTop;

					if (spriteRect.Left == (currentAnimation.numFrames - 1) * frameSize)
						spriteRect.Left = 0;
					else spriteRect.Left += frameSize;
				}
				animationClock.Restart();
			}

			sprite.TextureRect = spriteRect;
		}

		public void Draw(RenderWindow window)
		{
			window.Draw(sprite);
		}
	}
}
