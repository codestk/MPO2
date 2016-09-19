using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirebirdSql.Data.FirebirdClient;
namespace Stk.DB
{
    public class TransactionSet
    {
        string _SqlCommand;
        public string SqlCommand
        {
            get
            {
                return _SqlCommand.Trim();
            }
            set
            {
                _SqlCommand = value;
            }
        }

        private List<FbParameter> _Parameter;
        public List<FbParameter> Parameter
        {
            get
            {
                return _Parameter;
            }
            set
            {
                _Parameter = value;
            }
        }


    }
}