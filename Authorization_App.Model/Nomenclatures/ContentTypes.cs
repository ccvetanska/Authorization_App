﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_App.Nomenclatures
{
    [Serializable]
    public class ContentTypes
    {
        public enum ContentType
        {
            Text,
            Code,
            Video,
            Audio
        }
    }
}