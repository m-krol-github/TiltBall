using UnityEngine;

/// <summary>
/// Scale By animation.
/// Component should get how much to shrink or expand.
/// </summary>
public class ScaleByAnimation : BaseAnimation
{
    [Header("Scale By")]

    // How much to scale.
    public Vector3 targetOffset;

    // Starting scale.
    private Vector3 startScale;
    // Calculated end scale.
    private Vector3 targetScale;

    /// <summary>
    /// Initializing variables for animation.
    /// </summary>
    public override void StartAnimation()
    {
        startScale = transform.localScale;
        targetScale = startScale + targetOffset;
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
    /// On finish scale object to target scale.
    /// </summary>
    protected override void FinishAnimation()
    {
        //element.transform.localScale = targetScale;
        base.FinishAnimation();
    }
}