using System;
using Lab08.ParkingLot.Enums;

namespace Lab08.ParkingLot.Data.DataBase
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string Number { get; set; }

        public DiscountCard DiscountCard { get; set; }

        public VehicleCategory VehicleCategory { get; set; }

        public DateTime EntryTime { get; set; }
    }
}
