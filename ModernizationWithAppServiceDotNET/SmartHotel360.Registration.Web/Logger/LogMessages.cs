namespace SmartHotel.Registration.Logger
{
    public static class LogMessages
    {
        #region Informational Messages

        public const string StartedPageLoadInformation = "Module-{ModuleName}: Started Page Load with event id: {EventID}, Correlation id {CorrelationID}";

        public const string EndedPageLoadInformation = "Module-{ModuleName}: Ended Page Load with event id: {EventID}, Correlation id {CorrelationID}";

        public const string GetAllBookingsTimerDescription = "Time taken to fetch today's bookings from database";

        public const string GetAllBookingsTimerOperation = "GetAllBookingsForToday";

        public const string BeginningOperationMessage = "Beginning Operation {TimedOperationId}: {TimedOperationDescription}, Event Id: {EventId}, Correlation Id: {CorrelationId}";

        public const string CompletedOperationMessage = "Completed Operation {TimedOperationId}: {TimedOperationDescription} in {TimedOperationElapsed} " +
            "({TimedOperationElapsedInMs} ms), " +
            "Event Id: {EventId}, " +
            "Correlation Id: {CorrelationId}";

        #endregion

        #region Error Messages

        public const string UnhandledExceptionOccurred = "Module-{ModuleName}: Unhandled exception occured. Exception details: {ExceptionDetails}, Exception Handler {ExceptionHandler}";

        public const string PageLoadExceptionOccurred = "Module-{ModuleName}:Exception occured in Page load method of Home Page. Exception details: {ExceptionDetails}.";

        #endregion

        #region Warning Messages

        #endregion
    }
}