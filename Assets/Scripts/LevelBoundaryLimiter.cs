using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    /// <summary>
    /// ������������ �������. �������� � ������ �� �������� LevelBoundary, ���� ������� ������� �� �����
    /// �������� �� ������, ������� ���� ����������
    /// </summary>
    
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        private void Update()
        {
            if (LevelBoundary.Instance == null) return;

            var levelBoundary = LevelBoundary.Instance;
            var r = levelBoundary.Radius;

            if(transform.position.magnitude > r)
            {
                if(levelBoundary.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * r;
                }

                if (levelBoundary.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = -transform.position.normalized * r;
                }
            }
        }
    }
}


