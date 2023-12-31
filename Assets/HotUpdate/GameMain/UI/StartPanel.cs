﻿using DemoProject;

namespace ACFrameworkCore
{
    public class StartPanel : UIBase
    {
        //public StartPanel(EUIType type, EUIMode mod, EUILucenyType lucenyType, bool isClearStack = false) : base(type, mod, lucenyType, isClearStack)
        //{
        //    type = EUIType.Normal;
        //    mod = EUIMode.HideOther;
        //    lucenyType = EUILucenyType.ImPenetrable;
        //}

        public override void UIAwake()
        {
            base.UIAwake();
            InitUIBase(EUIType.Normal, EUIMode.HideOther, EUILucenyType.ImPenetrable);
            RigisterButtonObjectEvent("Setting",
               p =>
               {
                   OpenUIForm<SettingPanel>("Setting");
               });
            RigisterButtonObjectEvent("About",
               p => OpenUIForm<AboutPanel>("About")
               );
        }
    }
}
