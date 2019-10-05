using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    //目标
    public Transform target;

    //距离
    public float distance = 5f;

    //右键旋转控制部分
    //旋转速度
    private float speedX = 240;
    private float speedY = 120;
    //Y轴旋转的角度限制
    private float minLimitY = 45;
    private float maxLimitY = 55;
    //旋转角度
    private float mX = 0.0f;
    private float mY = 0.0f;

    //鼠标缩放控制部分
    //鼠标缩放距离最值
    private float maxDistance = 10;
    private float minDistance = 1.5f;
    //鼠标缩放速度
    private float zoomSpeed = 2f;

    //差值控制部分
    //是否启用差值计算
    public bool isNeedDamping = false;
    //差值速度
    public float dampingSpeed = 10f;

    private Quaternion mRotation;
    private Vector3 mPosition;

    void Start()
    {
        //初始化旋转角度
        mX = transform.eulerAngles.x;
        mY = transform.eulerAngles.y;
        mX += Input.GetAxis("Mouse X") * speedX * 0.02f;
        mY -= Input.GetAxis("Mouse Y") * speedY * 0.02f;
        mY = Mathf.Clamp(mY, minLimitY, maxLimitY);
        mRotation = Quaternion.Euler(mY, mX, 0);      
        transform.rotation = mRotation;
        target.rotation = Quaternion.Euler(new Vector3(0, mX, 0)); 
    }
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            mX += Input.GetAxis("Mouse X") * speedX * 0.02f;
            mY -= Input.GetAxis("Mouse Y") * speedY * 0.02f;         
            mY = Mathf.Clamp(mY, minLimitY, maxLimitY);//Y轴角度范围限制   
            mRotation = Quaternion.Euler(mY, mX, 0);//计算旋转，转化成欧拉角
            transform.rotation = mRotation;
            target.rotation = Quaternion.Euler(new Vector3(0, mX, 0));  //旋转相机
        }
        //鼠标滚轮缩放部分控制
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        mPosition = mRotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
        if (isNeedDamping)
        {
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * dampingSpeed);
        }
        else
        {
            transform.position = mPosition;
        }
    }
}
