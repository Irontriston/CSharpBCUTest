using System;



public class BaseEntity
{
	public long Health, MaxHealth;
	public int FactionId, ForwardDirection;
	public float Position, LastPosition;
	bool DeathSurge = false;
	public bool IsDead = false;
	public long DamageDealt = 0L, DamageTaken = 0L;
	public int TimeAlive = 0, DrawLayer;
	bool IsActingBase;
	public Class1()
	{
	}
}
