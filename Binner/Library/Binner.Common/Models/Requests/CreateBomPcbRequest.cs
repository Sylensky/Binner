﻿namespace Binner.Common.Models.Requests
{
    public class CreateBomPcbRequest
    {
        public int ProjectId { get; set; }

        /// <summary>
        /// Name of pcb
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of pcb
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The serial format template. Example: SN000000000
        /// </summary>
        public string? SerialNumberFormat { get; set; }

        /// <summary>
        /// The initial serial number
        /// </summary>
        public string? SerialNumber { get; set; }
    }
}