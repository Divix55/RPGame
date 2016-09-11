using System;
using System.Collections.Generic;
using SFML.System;

namespace RPGame
{
	public class AnimatedCharacterWithAI : AnimatedCharacter
	{
		public List<Waypoint> Waypoints { get; set;}
		private int nextWaypointIndex = 1;

		Clock aiClock;

		public AnimatedCharacterWithAI(string filename, int framesize) : base(filename, framesize)
		{
			aiClock = new Clock();
		}

		public override void Update(float deltaTime)
		{
			followWaypoints();

			base.Update(deltaTime);
		}

		private void followWaypoints()
		{
			if (Waypoints != null)
			{
				Waypoint nextWaypoint = Waypoints[nextWaypointIndex];

				float xDifference = nextWaypoint.XPos - this.xpos;
				float yDifference = nextWaypoint.YPos - this.ypos;
				float absXDifference = Math.Abs(xDifference);
				float absYDifference = Math.Abs(yDifference);

				if (absXDifference < 10 && absYDifference < 10)
				{
					if (nextWaypointIndex < Waypoints.Count - 1)
						nextWaypointIndex++;
					else
						nextWaypointIndex = 0;
				}
				if (absXDifference > absYDifference)
				{
					if (xDifference > 0)
					{
						this.CurrentState = CharacterState.MovingRight;
					}
					if (xDifference < 0)
					{
						this.CurrentState = CharacterState.MovingLeft;
					}
				}
				else 
				{
					if (yDifference > 0)
					{
						this.CurrentState = CharacterState.MovingDown;
					}
					if (yDifference < 0)
					{
						this.CurrentState = CharacterState.MovingUp;
					}
				}
			}
		}
	}
}

