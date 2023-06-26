#nullable disable

namespace App.Tests.Models
{
	public class EngineData
	{
        public int NumberOfInstances { get; set; }
		public string InstanceType { get; set; }
		public int NumberOfGPUs { get; set; }
		public string GPUType { get; set; }
        public string LocalSSD { get; set; }
        public string DatacenterLocation { get; set; }
    }
}
