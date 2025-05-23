﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move_To_Center_Wave7: MonoBehaviour
{
    // Tốc độ di chuyển
    public float speed = 3.0f;
    public float X_Offset = 0;
    public float Y_Offset = 0;
    // Vị trí mục tiêu
    private Vector3 targetPosition;

    // Khởi tạo
    protected void Start()
    {
        // Tìm kiếm canvas trong scene
        Canvas canvas = FindObjectOfType<Canvas>();

        // Tính vị trí giữa khung màn hình
        targetPosition = new Vector3(canvas.transform.position.x + X_Offset, canvas.transform.position.y + Y_Offset, 0f);
    }

    public void Update()
    {
        // Di chuyển gameObject về vị trí mục tiêu
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);

        // Kiểm tra xem khoảng cách giữa vị trí hiện tại và vị trí mục tiêu có nhỏ hơn ngưỡng hay không
        if (Vector3.Distance(gameObject.transform.position, targetPosition) == 0.0f)
        {
            // Dừng di chuyển
            gameObject.transform.position = targetPosition;
            speed = 0.0f;
        }
    }
}
