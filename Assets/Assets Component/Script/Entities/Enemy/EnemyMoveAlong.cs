using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAlong : EnemyBase
{
    [Header("Move Along Component")]
    public WallDetector wallDetector;

    #region MonoBehaviour Callbacks

    private void Start()
    {
        gameObject.name = enemyDataSO.enemyName;
    }
    
    private void FixedUpdate()
    {
        RohoxMove();
    }

    #endregion
    
    #region Tsukuyomi Callbacks

    private void RohoxMove()
    {
        transform.Translate(Vector2.left * (enemyDataSO.EnemyMoveSpeed * Time.deltaTime));
        
        if (IsWall())
        {
            EnemyFlip();
        }
    }

    private bool IsWall()
    {
        return Physics2D.OverlapCircle(wallDetector.wallChecker.position, wallDetector.wallCheckerRadius,
            wallDetector.wallLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(wallDetector.wallChecker.position, wallDetector.wallCheckerRadius);
    }

    #endregion
   
}
