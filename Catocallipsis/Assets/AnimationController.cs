using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public AnimationClip idleAnimation;
    public AnimationClip shootingAnimationRight;
    public AnimationClip shootingAnimationTopRight;
    public AnimationClip shootingAnimationUp;
    public AnimationClip shootingAnimationTopLeft;
    public AnimationClip shootingAnimationLeft;
    public AnimationClip shootingAnimationBottomLeft;
    public AnimationClip shootingAnimationDown;
    public AnimationClip shootingAnimationBottomRight;

    private Animator animator;
    private Transform playerTransform;
    private bool isShooting;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = transform;
    }

    private void Update()
    {
        // Get the mouse position in world space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from player to mouse position
        Vector2 direction = mousePosition - (Vector2)playerTransform.position;

        // Calculate the angle of the direction vector in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Convert the angle to 8 directions (0, 45, 90, 135, 180, -135, -90, -45)
        int directionIndex = Mathf.RoundToInt(angle / 45f) * 45;

        // Convert the direction index to a shooting animation clip
        AnimationClip shootingAnimation = GetShootingAnimationClip(directionIndex);

        // Check if shooting animation should play
        isShooting = Input.GetMouseButton(0);

        // Play the shooting animation if shooting, otherwise play idle animation or directional animation
        if (isShooting)
        {
            animator.Play(shootingAnimation.name);
        }
        else if (direction.magnitude > 0)
        {
            // If not shooting and there's movement, play the directional animation
            animator.Play(shootingAnimation.name);
        }
        else
        {
            // If not shooting and no movement, play the idle animation
            animator.Play(idleAnimation.name);
        }

        // Flip the sprite if shooting to the left
        bool flipSprite = (directionIndex < -90 || directionIndex > 90);
        SetSpriteFlip(flipSprite);

        // Print the current animation name
        Debug.Log("Current Animation: " + (isShooting ? shootingAnimation.name : (direction.magnitude > 0 ? shootingAnimation.name : idleAnimation.name)));
    }

    private AnimationClip GetShootingAnimationClip(int directionIndex)
    {
        switch (directionIndex)
        {
            case 0:
                return shootingAnimationRight;
            case 45:
                return shootingAnimationTopRight;
            case 90:
                return shootingAnimationUp;
            case 135:
                return shootingAnimationTopLeft;
            case 180:
            case -180:
                return shootingAnimationLeft;
            case -135:
                return shootingAnimationBottomLeft;
            case -90:
                return shootingAnimationDown;
            case -45:
                return shootingAnimationBottomRight;
            default:
                return idleAnimation;
        }
    }

    private void SetSpriteFlip(bool flip)
    {
        // Get the current sprite renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the sprite flip based on the flip flag
        spriteRenderer.flipX = flip;
    }
}
