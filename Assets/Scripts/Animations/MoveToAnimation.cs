using UnityEngine;

/// <summary>
/// Move To animation.
/// Component should get where it should move.
/// </summary>
public class MoveToAnimation : BaseAnimation
{
    [Header("Move To")]
    // Where it should move.
    public Vector3 targetPosition;

    // Starting position.
    private Vector3 startPosition;

    /// <summary>
    /// Initializing variables for animation.
    /// </summary>
    public override void StartAnimation()
    {
        startPosition = transform.localPosition;
        base.StartAnimation();
    }

    /// <summary>
    /// Internal animation loop.
    /// </summary>
    /// <param name="t">t receives values from 0.0 to 1.0.</param>
    protected override void UpdateAnimation(float t)
    {
        base.UpdateAnimation(t);
        transform.localPosition = CurvedValue(startPosition, targetPosition, t);
    }

    /// <summary>
    /// On finish move object to end position.
    /// </summary>
    protected override void FinishAnimation()
    {
        transform.localPosition = targetPosition;
        base.FinishAnimation();
    }
}