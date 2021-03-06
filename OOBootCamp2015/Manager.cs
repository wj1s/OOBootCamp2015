﻿using System.Linq;

namespace OOBootCamp2015
{
    public class Manager : BoyBase<ICanParkingAndStore>
    {
        public Manager(ICanParkingAndStore[] parkingAndStores) : base(parkingAndStores)
        {
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkingAndStores.FirstOrDefault(pl => !pl.IsFull);
        }

        protected override string GetReportHead()
        {
            return "M";
        }
    }
}