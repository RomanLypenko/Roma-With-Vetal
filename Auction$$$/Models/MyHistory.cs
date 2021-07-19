using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction___.Models
{
    public class MyHistory
    {
        public int Id { get; set; }
        public AllLots Lot { get; set; }//Лот на якому я зробив ставку

        public UsersModel WhoiAm { get; set; }//Я

        public int BidPrice { get; set; }
        public DateTime BidTime { get; set; }//Дата Час Ставки
    }
}
