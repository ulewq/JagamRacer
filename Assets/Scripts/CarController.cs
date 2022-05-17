using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";

    private const string VERTICAL = "Vertical";



    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float BreakForce;
    private bool IsBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float currentBreakForce;
    [SerializeField] private float MaxSteerAngle;

    [SerializeField] private WheelCollider FrontLeftWheeleCollider;
    [SerializeField] private WheelCollider FrontRightWheeleCollider;
    [SerializeField] private WheelCollider rearLeftWheeleCollider;
    [SerializeField] private WheelCollider rearRightWheeleCollider;

    [SerializeField] private Transform FrontLeftWheeleTransform;
    [SerializeField] private Transform FrontRightWheeleTransform;
    [SerializeField] private Transform rearLeftWheeleTransform;
    [SerializeField] private Transform rearRightWheeleTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        IsBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        FrontLeftWheeleCollider.motorTorque = verticalInput * motorForce;
        FrontRightWheeleCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = IsBreaking ? BreakForce : 0f;
        applyBreaking();
    }

    private void applyBreaking()
    {

        FrontRightWheeleCollider.brakeTorque = currentBreakForce;
        FrontLeftWheeleCollider.brakeTorque = currentBreakForce;
        rearRightWheeleCollider.brakeTorque = currentBreakForce;
        rearLeftWheeleCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = MaxSteerAngle * horizontalInput;
        FrontLeftWheeleCollider.steerAngle = currentSteerAngle;
        FrontRightWheeleCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftWheeleCollider, FrontLeftWheeleTransform);
        UpdateSingleWheel(FrontRightWheeleCollider, FrontRightWheeleTransform);
        UpdateSingleWheel(rearRightWheeleCollider, rearRightWheeleTransform);
        UpdateSingleWheel(rearLeftWheeleCollider, rearLeftWheeleTransform);
    }

    private void UpdateSingleWheel(WheelCollider WheeleCollider, Transform WheeleTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheeleCollider.GetWorldPose(out pos, out rot);
        WheeleTransform.rotation = rot;
        WheeleTransform.position = pos;
    }

}