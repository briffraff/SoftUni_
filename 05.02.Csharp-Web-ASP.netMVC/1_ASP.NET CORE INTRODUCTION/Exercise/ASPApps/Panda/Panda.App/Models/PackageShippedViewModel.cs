﻿namespace Panda.App.Models
{
    public class PackageShippedViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string EstimatedDeliveryDate { get; set; }

        public string Recipient { get; set; }

    }
}
