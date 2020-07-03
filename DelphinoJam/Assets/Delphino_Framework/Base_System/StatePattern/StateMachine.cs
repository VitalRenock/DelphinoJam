namespace StateStuff
{
	public class StateMachine<T>
	{
		public BaseState<T> currentState { get; private set; }
		public T Agent;

		public StateMachine(T agent)
		{
			Agent = agent;
			currentState = null;
		}

		public void ChangeState(BaseState<T> newState)
		{
			if (currentState != null)
				currentState.ExitState(Agent);
			currentState = newState;
			currentState.EnterState(Agent);
		}

		public void Update()
		{
			if (currentState != null)
				currentState.UpdateState(Agent);
		}
	}
}