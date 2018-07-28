using System;

namespace Model
{
    public class UserVm
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string Station { get; set; }
        public int StationId { get; set; }
    }
}
