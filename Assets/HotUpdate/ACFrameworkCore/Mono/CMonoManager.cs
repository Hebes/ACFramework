﻿using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using Time = UnityEngine.Time;

namespace ACFrameworkCore
{
    public class CMonoManager : SingletonInit<CMonoManager>,ISingletonInit
    {
        public void Init()
        {
            GameObject monoTemp = new GameObject("Mono");
            monoController = monoTemp.AddComponent<MonoController>();
            GameObject.DontDestroyOnLoad(monoTemp);
            DLog.Log("初始化Mono完毕!");
        }
        public MonoController monoController;

        private float m_Time = 0f;

        public void OnAddAwakeEvent(UnityAction unityAction)
        {
            monoController.OnAddAwakeEvent(unityAction);
        }
        public void OnRemoveAwakeEvent(UnityAction unityAction)
        {
            monoController.OnRemoveAwakeEvent(unityAction);
        }

        public void OnAddUpdateEvent(UnityAction unityAction)
        {
            monoController.OnAddUpdateEvent(unityAction);
        }
        public void OnRemoveUpdateEvent(UnityAction unityAction)
        {
            monoController.OnRemoveUpdateEvent(unityAction);
        }

        public void OnAddFixedUpdateEvent(UnityAction unityAction)
        {
            monoController.OnAddFixedUpdateEvent(unityAction);
        }
        public void OnRemoveFixedUpdateEvent(UnityAction unityAction)
        {
            monoController.OnRemoveFixedUpdateEvent(unityAction);
        }

        public Coroutine MonoStartCoroutine(IEnumerator routine)
        {
            return monoController.MonoStartCoroutine(routine);
        }
        public Coroutine MonoStartCoroutine(string methodName, [DefaultValue("null")] object value)
        {
            return monoController.MonoStartCoroutine(methodName, value);
        }
        public Coroutine MonoStartCoroutine(string methodName)
        {
            return monoController.MonoStartCoroutine(methodName);
        }
        public void MonoStopCoroutine(string methodName, [DefaultValue("null")] object value)
        {
            monoController.StopCoroutine(methodName);
        }
        public void MonoStopCoroutine(IEnumerator routine)
        {
            monoController.StopCoroutine(routine);
        }

        public void Pause()
        {
            m_Time = Time.timeScale;
            Time.timeScale = 0f;//会影响UpData的Time.DataTime,但是Update函数仍在执行 和 FixedUpdate
        }
        public void UnPause(float m_Time)
        {
            Time.timeScale = m_Time;
            this.m_Time = Time.timeScale;
        }
    }
}
