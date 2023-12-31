﻿using Core.Models.Serilog;

namespace Core.Models.DTO
{
    public class DifferencesEvent
    {
        public readonly string ApplicationName;
        public List<EventLog> ExceptionEvents { get; set; } = new List<EventLog>();
        public int DifferencesCount { get; set; } = 1;

        public DifferencesEvent(string applicationName, List<EventLog> exceptionEvents, int differencesCount) =>
          (ApplicationName, ExceptionEvents, DifferencesCount) = (applicationName, exceptionEvents, differencesCount);
    }
}
