using System.Collections.Generic;
using _8mpBl.Model.Operation;

namespace _8mpBl.Model.User
{
    public class UserDetailVm
    {
        public int id { get; set; }
        public string username { get; set; }
        public List<OperationVm> operations { get; set; }
        public List<string> group { get; set; }
    }
}
