using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Dodge : Agent
{
    [SerializeField] private Transform targetTransform;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = Vector3.zero;
        SetReward(+1f);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveSpeed = 6f;
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime * moveSpeed;
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continousActions = actionsOut.ContinuousActions;
        continousActions[0] = Input.GetAxisRaw("Horizontal");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<wall>(out wall wall))
        {
            SetReward(-1f);
            EndEpisode();
        }
        else
        {
            SetReward(+1f);
            EndEpisode();
        }
        if (other.TryGetComponent<ball>(out ball ball))
        {
            SetReward(-2f);
            EndEpisode();
        }
        else
        {
            SetReward(+2f);
            EndEpisode();
        }
    }
}
