using InControl;

public class InputBindings : PlayerActionSet {

    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerAction Right;
    public PlayerAction Left;
    
    public InputBindings()
    {
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        Right = CreatePlayerAction("Right");
        Left = CreatePlayerAction("Left");
    }

    public static InputBindings CreateWithDefaultBindings()
    {
        var inputBindings = new InputBindings();

        inputBindings.Up.AddDefaultBinding(Key.UpArrow);
        inputBindings.Up.AddDefaultBinding(Key.W);
        inputBindings.Up.AddDefaultBinding(InputControlType.LeftStickUp);

        inputBindings.Down.AddDefaultBinding(Key.DownArrow);
        inputBindings.Down.AddDefaultBinding(Key.S);
        inputBindings.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        inputBindings.Right.AddDefaultBinding(Key.RightArrow);
        inputBindings.Right.AddDefaultBinding(Key.D);
        inputBindings.Right.AddDefaultBinding(InputControlType.RightStickRight);

        inputBindings.Left.AddDefaultBinding(Key.LeftArrow);
        inputBindings.Left.AddDefaultBinding(Key.A);
        inputBindings.Left.AddDefaultBinding(InputControlType.RightStickLeft);

        return inputBindings;
    }

}
