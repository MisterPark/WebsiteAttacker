using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebsiteAttacker
{
  class Logger
  {
    static ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
    


    public static void Enqueue(string log)
    {
      logQueue.Enqueue(DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss] ") + log);
    }

    public static List<string> Dequeue()
    {
      List<string> list = new List<string>();
      while (logQueue.Count > 0)
      {
        string log;
        if (logQueue.TryDequeue(out log))
        {
          list.Add(log);
        }

      }
      return list;
    }


  }
}
