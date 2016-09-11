using System;
using SFML.Window;

namespace RPGame
{
	public class Player : AnimatedCharacterWithAI
	{
		public Player() : base("Sprites/char.png", 64)
		{
			Anim_Up = new Animation(512, 0, 9);
			Anim_Left = new Animation(576, 0, 9);
			Anim_Down = new Animation(640, 0, 9);
			Anim_Right = new Animation(704, 0, 9);

			moveSpeed = 150;
			animationSpeed = 0.05f;
		}

		public override void Update(float deltaTime)
		{
			this.CurrentState = CharacterState.None;

			if (Keyboard.IsKeyPressed(Keyboard.Key.W))
			{
				this.CurrentState = CharacterState.MovingUp;
			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.A))
			{
				this.CurrentState = CharacterState.MovingLeft;
			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.S))
			{
				this.CurrentState = CharacterState.MovingDown;
			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.D))
			{
				this.CurrentState = CharacterState.MovingRight;
			}

			base.Update(deltaTime);
		}
	}
}

