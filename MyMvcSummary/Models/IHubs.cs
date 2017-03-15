using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MyMvcSummary.Models
{
    public interface IHubs
    {
          Task OnConnected();
          Task OnDisconnected(bool stopCalled);
    }
}
