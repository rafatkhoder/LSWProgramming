using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player Instance;
    public AnimationState animationState;
    public PlayerInteraction playerInteraction;
    public PayerEquipmentT playerEquipment;
    public PlayerCloothes PlayerCloothes;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        UpdtaeInput();
        animationState.UpdateAnimation(this);
        
    }
    private void FixedUpdate()
    {
        UpdatePosition(this);
    }
}
