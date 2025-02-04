using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Core.Domain.Common
{
	public abstract class BaseEntity
	{
        public DateTime CreatedAt
        {
            get;
            set;
        }
        public DateTime? UpdatedAt
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        } = true;
	}
}