﻿namespace BackendApartmentReservation.Infrastructure.Exceptions
{
    using System;

    public class ErrorResponse
    {
        public string ErrorCode { get; set; }

        public Exception Exception { get; set; }
    }
}