using GodotEngine;

public class MovingPlatform : Node2D
{
    [PropertyInfo(Godot.TYPE_VECTOR2)]
    public Vector2 motion = new Vector2();

    [PropertyInfo(Godot.TYPE_REAL)]
    public float cycle = 1.0f;
    [PropertyInfo(Godot.TYPE_REAL)]
    public float accum = 0.0f;

    void _fixed_process(float delta)
    {
        accum += delta * (1.0f / cycle) * Mathf.PI * 2.0f;
        accum = accum % (Mathf.PI * 2.0f);
        float d = Mathf.sin(accum);
        Matrix32 xf = Matrix32.Identity;
        xf[2] = motion * d;
        RigidBody2D platform = get_node("platform") as RigidBody2D;
        platform.set_transform(xf);
    }

    void _ready()
    {
        set_fixed_process(true);
    }
}
