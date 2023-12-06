﻿using System;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class ButtonViewModel
    {
        public Guid ButtonId { get; set; }
        public string ButtonName { get; set; }
        public string ButtonNameEn { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
