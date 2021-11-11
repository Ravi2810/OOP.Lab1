using System;
using OOP.Lab1.Geometry2D;

namespace OOP.Lab1.Particles
{
	public abstract class Particle
	{
		public double Speed { get; set; }

		private Point Position { get; set; }

		private Vector Direction { get; set; }

		/// <summary>
		/// The default constructor sets the particle position and direction vector to (0,0)
		/// and the speed to 0.
		/// </summary>
		public Particle()
		{

		}

		public Particle(Point position, Vector direction, double speed)
		{


			Position = position;
			Direction = direction;
			Speed = speed;


		}
		/// <summary>
		/// Sets the particle's position in 2D space
		/// </summary>
		/// <param name="px">The x coordinate</param>
		/// <param name="py">The y coordinate</param>
		public void SetCoords(double? px, double? py)
		{
			Position.SetCoords(px, py);
		}
		/// <summary>
		/// Get the x and y position coordinates of the particle
		/// </summary>
		/// <param name="px">The x coordinate</param>
		/// <param name="py">The y coordinate</param>
		public void GetCoords(out double px, out double py)
		{

			Position.GetCoords(out px, out py);
		}
		/// <summary>
		/// Sets the particle's direction vector
		/// </summary>
		/// <param name="dx">The x component of the direction vector</param>
		/// <param name="dy">The y component of the direction vector</param>
		/// <exception cref="ArgumentOutOfRangeException">Throws if the x or y component is > 1 or < -1."</exception>
		public void SetDirection(double dx, double dy)
		{

			SetDirection(dx, dy);
		}
		/// <summary>
		/// Get the x and y components of the particle direction vector
		/// </summary>
		/// <param name="dx">The x coordinate</param>
		/// <param name="dy">The y coordinate</param>
		public void GetDirection(out double dx, out double dy)
		{
			dx = Direction.DX;
			dy = Direction.DY;
		}
		/// <summary>
		/// Drifts (moves) the particle in space
		/// </summary>
		/// <param name="time">The amount of time the particle drifts</param>
		public void Drift(double time)
		{
			var newX = Position.X + Direction.DX * Speed * time;
			var newY = Position.Y + Direction.DY * Speed * time;
			this.SetCoords(newX, newY);
		}
		/// <summary>
		/// Gives the particle a random direction vector
		/// </summary>
		/// <param name="r1">A random number in the interval [0,1]</param>
		/// <param name="r2">A random number in the interval [0,1]</param>
		public void SetRandomDirection(double r1, double r2)
		{
			double dx = 2 * r1 - 1;
			double dy = Math.Sqrt(1 - dx * dx) * Math.Cos(2 * Math.PI * r2);
			Direction.Set(dx, dy);
		}
		public abstract void Update(double frequency, double speed, Polarization pol);
		public override string ToString()
		{
			return $"Position: {Position}\n" +
				   $"Direction: {Direction}\n" +
				   $"Speed: {Speed}\n";
		}
	}
}
