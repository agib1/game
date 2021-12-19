using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GOAP controller to decide states of human AI
public class GOAPController : MonoBehaviour
{
    PersonGoals[] goals;
    PersonActions[] actions;

    PersonGoals activeGoal;
    PersonActions activeAction;


    //get goals and actions connected to Person object
    void Start()
    {
        goals = GetComponents<PersonGoals>();
        actions = GetComponents<PersonActions>();
    }

    void Update()
    {
        PersonGoals bestGoal = null;
        PersonActions bestAction = null;

        foreach (var goal in goals)
        {
            goal.OnGoalRunning();

            // if goal cant run, skip.
            if (!goal.GoalCanRun())
            {
                continue;
            }

            //if current goal is priororitzed over next, skip.
            if (!(bestGoal == null || goal.CalculatePriority() > bestGoal.CalculatePriority()))
            {
                continue;
            }

            PersonActions candidateAction = null;

            // if not, select action to run
            foreach (var action in actions)
            {
                //if not action for current goal, skip.
                if (!(action.GetGoals().Contains(goal.GetType())))
                {
                    continue;
                }

                // if cost of action less than next, update action.
                if (candidateAction == null || action.Cost() < candidateAction.Cost())
                {
                    candidateAction = action;
                }

            }

            // then set as best
            if (candidateAction != null)
            {
                bestGoal = goal;
                bestAction = candidateAction;
            }
        }

        //set current goals as best one and start goal state
        if (activeGoal == null)
        {
            activeGoal = bestGoal;
            activeAction = bestAction;

            if (activeGoal != null)
            {
                activeGoal.OnGoalActivated();
            }
            if (activeAction != null)
            {
                activeAction.OnActionActivated();
            }
        }
        else if (activeGoal == bestGoal)
        {
            // if better action, stop current and start better.
            if (activeAction != bestAction)
            {
                activeAction.OnActionDeactivated();
                activeAction = bestAction;
                activeAction.OnActionActivated();
            }
        }
        // if no lonter best goal, deactivate state and start better one
        else if (activeGoal != bestGoal)
        {
            activeGoal.OnGoalDeactivated();
            activeAction.OnActionDeactivated();

            activeGoal = bestGoal;
            activeAction = bestAction;

            if (activeGoal != null)
            {
                activeGoal.OnGoalActivated();
            }
            if (activeAction != null)
            {
                activeAction.OnActionActivated();
            }
        }

        if (activeAction != null)
        {

            activeAction.OnActionRunning();
        }
    }
}