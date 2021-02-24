using System;

namespace TrulliManager_MongoDB.ViewModel
{
    public class CreateTrulloInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public Guid PropertyId { get; set; }
    }
}
