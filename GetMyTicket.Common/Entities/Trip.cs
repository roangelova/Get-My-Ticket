﻿using GetMyTicket.Common.Entities.Contracts;
using GetMyTicket.Common.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMyTicket.Common.Entities
{
    public class Trip
    {
        public Guid TripId { get; set; }

        public TypeOfTransportation TypeOfTransportation { get; set; }

        public TransportationProvider TransportationProvider { get; set; }

        [ForeignKey(nameof(TransportationProvider))]
        public Guid TransportationProviderId { get; set; }

        public Vehicle Vehicle { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public double Price { get; set; }

    }
}