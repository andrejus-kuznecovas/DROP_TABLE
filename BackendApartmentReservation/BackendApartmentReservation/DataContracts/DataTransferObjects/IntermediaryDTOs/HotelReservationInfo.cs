﻿namespace BackendApartmentReservation.DataContracts.DataTransferObjects.IntermediaryDTOs
{
    using System;

    public class HotelReservationInfo
    {
        public bool Required { get; set; }

        public string HotelName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}