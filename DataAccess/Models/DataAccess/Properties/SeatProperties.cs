using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.DataAccess.Models.DataAccess.Properties
{
    public class SeatProperties
    {
        public Guid Id { get; set; }
        public string SalesPackage { get; set; }
        public string ModelNumber { get; set; }
        public string SecondaryMaterial { get; set; }
        public string Configuration { get; set; }
        public string UpholsteryMaterial { get; set; }
        public string UpholsteryColor { get; set; }
        public string FillingMaterial { get; set; }
        public string FinishType { get; set; }
        public string AdjustableHeadrest { get; set; }
        public decimal MaximumLoadCapacity { get; set; }
        public string OriginofManufacture { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal SeatHeight { get; set; }
        public decimal LegHeight { get; set; }
        public string WarrantySummary { get; set; }
        public string WarrantyServiceType { get; set; }
        public string CoveredInWarranty { get; set; }
        public string NotCoveredInWarranty { get; set; }
        public int DomesticWarranty { get; set; }
        
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
