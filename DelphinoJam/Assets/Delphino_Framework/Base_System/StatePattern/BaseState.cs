namespace StateStuff
{
	public abstract class BaseState<T>
	{
		public abstract void EnterState(T agent);
		public abstract void UpdateState(T agent);
		public abstract void ExitState(T agent);
	}
}