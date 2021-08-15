using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base animation class.
/// Override methods in Animation Controls region to create new animation.
/// </summary>
public class BaseAnimation : MonoBehaviour
{
    // Types of available animation curves
    public enum AnimationCurveEnum
    {
        Hermite,
        Sinerp,
        Coserp,
        Berp,
        Bounce,
        Lerp,
        Clerp
    }

    [Header("Animation Settings")]
    // Animation duration
    public float duration = 1f;
    // Animation delay
    public float delay = 0f;
    // Is animation looping
    public bool isLooping = false;

    // Should animation start playing on enable
    public bool autoPlay = false;
    // Should animation destroy itself after end of animation
    public bool autoDestroy = true;

    // Animation curve
    public AnimationCurveEnum animationCurve = AnimationCurveEnum.Hermite;

    // On finish event
    public UnityAction OnAnimationFinished;

    // Is animation playing
    protected bool isPlaying = false;

    // Internal animation timer
    protected float timer = 0f;

    #region [Animation Controls]

    /// <summary>
    /// Method called to start animating with this component.
    /// When overriding, you can treat it as Start or Awake function.
    /// </summary>
    public virtual void StartAnimation()
    {
        isPlaying = true;
    }

    /// <summary>
    /// Internal animation loop.
    /// You can override this function but I would recomment to override UpdateAnimation(float t).
    /// </summary>
    protected virtual void UpdateAnimation()
    {
        UpdateAnimation((timer - delay) / (duration));
    }

    /// <summary>
    /// Internal animation loop.
    /// You can override it and add your animation code. Comes with parameter "t" which has value from 0.0 to 1.0.
    /// </summary>
    /// <param name="t">t receives values from 0.0 to 1.0.</param>
    protected virtual void UpdateAnimation(float t)
    {
        // Here goes code for animation with t (0.0 -> 1.0)
    }

    /// <summary>
    /// Method used to pause animation.
    /// </summary>
    public virtual void PauseAnimation()
    {
        isPlaying = false;
    }

    /// <summary>
    /// Method used to stop animation.
    /// </summary>
    public virtual void StopAnimation()
    {
        PauseAnimation();
        timer = 0;
    }

    /// <summary>
    /// Method called on animation finished.
    /// </summary>
    protected virtual void FinishAnimation()
    {
        OnAnimationFinished?.Invoke();
        StopAnimation();

        if (autoDestroy)
        {
            Destroy(this);
        }
    }

    #endregion

    #region [Utils]

    /// <summary>
    /// Wrapper function to call different functions from Mathfx class.
    /// Float version.
    /// </summary>
    /// <returns>Curve Function value.</returns>
    /// <param name="start">Start value.</param>
    /// <param name="end">End value.</param>
    /// <param name="t">t receives values from 0.0 to 1.0.</param>
    protected float CurvedValue(float start, float end, float t)
    {
        switch (animationCurve)
        {
            case AnimationCurveEnum.Hermite:
                return Mathfx.Hermite(start, end, t);
            case AnimationCurveEnum.Sinerp:
                return Mathfx.Sinerp(start, end, t);
            case AnimationCurveEnum.Coserp:
                return Mathfx.Coserp(start, end, t);
            case AnimationCurveEnum.Berp:
                return Mathfx.Berp(start, end, t);
            case AnimationCurveEnum.Bounce:
                return start + ((end - start) * Mathfx.Bounce(t));
            case AnimationCurveEnum.Lerp:
                return Mathfx.Lerp(start, end, t);
            case AnimationCurveEnum.Clerp:
                return Mathfx.Clerp(start, end, t);
            default:
                return 0;
        }
    }

    /// <summary>
    /// Wrapper function to call different functions from Mathfx class.
    /// Vector2 version.
    /// </summary>
    /// <returns>Curve Function value.</returns>
    /// <param name="start">Start value.</param>
    /// <param name="end">End value.</param>
    /// <param name="t">t receives values from 0.0 to 1.0.</param>
    protected Vector2 CurvedValue(Vector2 start, Vector2 end, float t)
    {
        return new Vector2(CurvedValue(start.x, end.x, t), CurvedValue(start.y, end.y, t));
    }

    /// <summary>
    /// Wrapper function to call different functions from Mathfx class.
    /// Vector3 version.
    /// </summary>
    /// <returns>Curve Function value.</returns>
    /// <param name="start">Start value.</param>
    /// <param name="end">End value.</param>
    /// <param name="t">t receives values from 0.0 to 1.0.</param>
    protected Vector3 CurvedValue(Vector3 start, Vector3 end, float t)
    {
        return new Vector3(CurvedValue(start.x, end.x, t), CurvedValue(start.y, end.y, t), CurvedValue(start.z, end.z, t));
    }

    #endregion

    #region [Unity]

    /// <summary>
    /// Unity method called when component is enabled.
    /// Calls StartAnimation when autoPlay is enabled.
    /// </summary>
    private void OnEnable()
    {
        if (autoPlay)
        {
            StartAnimation();
        }
    }

    /// <summary>
    /// Unity method called each frame.
    /// Used for calling animation functions from [Animation Controls] region above.
    /// </summary>
    private void Update()
    {
        // Run only if animation should play.
        if (!isPlaying)
        {
            return;
        }

        // Increase internal timer.
        timer += Time.deltaTime;

        // Wait until delay.
        if (timer > delay)
        {
            UpdateAnimation();
        }

        // When timer hit value above animation duration
        if (timer > duration + delay)
        {
            // Lower timer if animation is looping
            if (isLooping)
            {
                timer -= duration;
            }
            // Or finish animation.
            else
            {
                FinishAnimation();
            }
        }
    }

    #endregion
}