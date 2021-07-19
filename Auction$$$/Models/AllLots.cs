using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction___.Models
{
    public class AllLots
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int InitialPrice { get; set; }
        public int Finalprice { get; set; }
        public int UserId { get; set; }
        public UsersModel User { get; set; }
        public List<MyHistory> LotBids { get; set; }



    }
}
