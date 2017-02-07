using InControl;

public class InputBindings : PlayerActionSet {

    public PlayerAction Forwards;
    public PlayerAction Backwards;
    public PlayerAction RotateClockwise;
    public PlayerAction RotateCounterClockwise;
    
    public InputBindings()
    {
        Forwards = CreatePlayerAction("Forwards");
        Backwards = CreatePlayerAction("Backwards");
        RotateClockwise = CreatePlayerAction("RotateClockwise");
        RotateCounterClockwise = CreatePlayerAction("RotateCounterClockwise");
    }

    public static InputBindings CreateWithDefaultBindings()
    {
        var inputBindings = new InputBindings();

        inputBindings.Forwards.AddDefaultBinding(Key.UpArrow);
        inputBindings.Forwards.AddDefaultBinding(Key.W);
        inputBindings.Forwards.AddDefaultBinding(InputControlType.LeftStickUp);

        inputBindings.Backwards.AddDefaultBinding(Key.DownArrow);
        inputBindings.Backwards.AddDefaultBinding(Key.S);
        //inputBindings.Backwards.AddDefaultBinding(InputControlType.LeftStickDown);

        inputBindings.RotateClockwise.AddDefaultBinding(Key.RightArrow);
        inputBindings.RotateClockwise.AddDefaultBinding(Key.D);
        //inputBindings.RotateClockwise.AddDefaultBinding(InputControlType.LeftStickRight);

        inputBindings.RotateCounterClockwise.AddDefaultBinding(Key.LeftArrow);
        inputBindings.RotateCounterClockwise.AddDefaultBinding(Key.A);
        //inputBindings.RotateCounterClockwise.AddDefaultBinding(InputControlType.LeftStickLeft);

        return inputBindings;
    }

}
