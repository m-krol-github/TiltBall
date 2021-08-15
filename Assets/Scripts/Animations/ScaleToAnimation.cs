using UnityEngine;

/// <summary>
/// Scale To animation.
/// Component should get to what size it should shrink or expand.
/// </summary>
public class ScaleToAnimation : BaseAnimation
{
    [Header("Scale To")]
    // To what value to scale.
    public Vector3 targetScale;

    // Starting scale.
    private Vector3 startScale;

    /// <summary>
    /// Initializing variables for animation.
    /// </summary>
    public override void StartAnimation()
    {
        startScale = transform.localScale;
        base.StartAnimation();
    }

    /// <summary>
    /// Internal animation loop.
    /// </summary>
    /// <param name="t">t receives values from 0.0 to 1.0.</param>
    protected override void UpdateAnimation(float t)
    {
        base.UpdateAnimation(t);
        transform.localScale = CurvedValue(startScale, targetScale, t);
    }

    /// <summary>
    /// On finish scale object to target value.
    /// </summary>
    protected override void FinishAnimation()
    {
        transform.localScale = targetScale;
        base.FinishAnimation();
    }
}
    