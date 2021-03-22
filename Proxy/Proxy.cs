using Data;
using Model;
using System.Collections.Generic;

namespace Proxy
{
    public class Proxy : IMonitore
    {
        private LogDB _logDB;

        public Proxy(LogDB logDB)
        {
            this._logDB = logDB;
        }

        public void SaveLog(string msg)
        {
            _logDB.Insert(msg);
        }

        public List<Log> Select()
        {
            return _logDB.Select();
        }
    }
}
