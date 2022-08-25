using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WomenEmpowermentAPI.ViewModels
{
    public class TraineeStatus
    {
        public int TraineeApplicationId { get; set; }
        public short Status { get; set; }

        public TraineeStatus()
        {
        }
    }
}
