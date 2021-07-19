using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction___.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int Balance { get; set; }
        public bool isReg { get; set; }
        public List<AllLots> MyLots { get; set; }
        public List<MyHistory> HistoriesBids { get; set; }


    }
}
