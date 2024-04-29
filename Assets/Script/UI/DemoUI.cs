﻿using System.Collections;
using Game.Extensions;
using Game.System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class DemoUI : BasePanel
    {
        private MapSystem _mapSystem;

        private Button _closeBtn;
        public override void InitPanel()
        {
            _mapSystem = GameBody.GetSystem<MapSystem>();

            _closeBtn = transform.FindByName<Button>("CloseBtn");

        }

        //public override void Show(IUiData uiData)
        //{
        //    EventSystem.Send(new MapInitFinishEvent()
        //    {
        //        Level = 1
        //    });
        //}

        public override void Refresh()
        {
            throw new global::System.NotImplementedException();
        }

        public override void Close()
        {
            throw new global::System.NotImplementedException();
        }


    }
}