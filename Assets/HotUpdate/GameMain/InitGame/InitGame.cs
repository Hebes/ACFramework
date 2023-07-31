﻿using ACFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using YooAsset;

public class InitGame
{
    public static List<GameObject> gos;
    public static async void Init()
    {
        string value = await InitRsv();
        DLog.Log(value);
        DLog.Log("开始创建物体");
        EnterGame();

        foreach (var game in gos)
        {
            game.gameObject.SetActive(false);
        }
    }


    private static async Task<string> InitRsv()
    {
        HashSet<ICore> _initHs = new HashSet<ICore>()
            {
                new DebugComponent(),
                new MonoComponent(),
                new ResComponent(),
                new AduioComponent(),
                new UIComponent(),
            };

        foreach (var init in _initHs)
        {
            init.ICroeInit();
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
        }
        return "核心框架模块已经全都初始化完毕1!";
    }

    /// <summary>
    /// 进入游戏
    /// </summary>
    private static void EnterGame()
    {
        DLog.Log("开始打开界面");
        UIComponent.Instance.OnCreatUI<PanelComponent>("Panel", EUILayer.System);
        //MonoComponent.Instance.MonoStartCoroutine(HideUI());
        //MonoComponent.Instance.Pause();
    }

    static IEnumerator HideUI()
    {
        yield return new WaitForSeconds(5);
        //UIComponent.Instance.OnCloseUI("Panel");
        //UIComponent.Instance.OnCreatUI<PanelComponent>("Panel", EUILayer.System);
        //MonoComponent.Instance.Pause();
    }
}