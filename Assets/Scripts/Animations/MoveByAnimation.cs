using UnityEngine;

/// <summary>
/// Move By animation.
/// Component should get how far should move.
/// </summary>
public class MoveByAnimation : BaseAnimation
{
    [Header("Move By")]
    // How far it should move.
    public Vector3 targetOffset;

    // Starting position.
    private Vector3 startPosition;
    // Calculated end position.
    private Vector3 targetPosition;

    /// <summary>
    /// Initializing variables for animation.
    /// </summary>
    public override void StartAnimation()
    {
        startPosition = transform.localPosition;
        targetPosition = startPosition + targetOffset;
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
    /// On finish move object to target position.
    /// </summary>
    protected override void FinishAnimation()
    {
        transform.localPosition = targetPosition;
        base.FinishAnimation();
    }
}