﻿using System;
using System.Collections.Generic;
using BlazorRpgPersona.Models;

namespace BlazorRpgPersonaContainer.Client.BusinessLogic
{
    public interface IFrameApplicationStatusReportReceiver
    {
        List<FrameApplicationStatusReport> FrameApplicationStatusReports { get; }

        event Action<FrameApplicationStatusReport> FrameApplicationStatusReportReceived;

        FrameApplicationStatusReport ReceiveStatusReport(FrameApplicationStatusReport frameApplicationStatusReport);
    }
}